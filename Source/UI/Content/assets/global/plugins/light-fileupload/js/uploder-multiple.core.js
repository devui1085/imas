uploader.multiple = {
    imageListManager: {
        lastIndex: 0,
        count:0,
        addImage: (imageData) => {
            if (imageData.source == 'server') {
                let image = '<img src="/AdImages/Pic400x250/' + imageData.name + '.png" class="thumb" title="' + imageData.name + '" />';
                //let fileName = 'File_' + uploader.multiple.imageListManager.lastIndex;
                let RowInfo = '<div id="' + imageData.name + '" class="info" source="' + imageData.source + '" ><div class="InfoContainer infoContainer-server">' +
                    '<div data_img="Imagecontainer">' + image + '</div>' +
                    '<div><button class="btn btn-block btn-danger app-btn-block" onclick="uploader.multiple.imageListManager.removeImage(\'' + imageData.name + '\')" >حذف</button>' + '</div>'
                '<div  class="detail" >' +
                  '</div><hr/></div>' +

                    '</div>';
                $('#Files').append(RowInfo);
            }
            else {
                let image = '<img src="' + imageData.fileContent + '" class="thumb" title="' + imageData.name + '" />';
                let fileName = 'File_' + uploader.multiple.imageListManager.lastIndex;
                let RowInfo = '<div id="' + fileName + '" class="info"><div class="InfoContainer infoContainer-client">' +
                    '<div data_img="Imagecontainer">' + image + '</div>' +
                    '<div><button class="btn btn-block btn-danger app-btn-block" onclick="uploader.multiple.imageListManager.removeImage(\'' + fileName + '\')" >حذف</button>' + '</div>'
              +  '<div  class="detail" >' +
                    '<div data-name="FileName" class="info">' + imageData.name + '</div>' +
                    '<div data-type="FileType" class="info">' + imageData.type + '</div>' +
                    '<div data-size="FileSize" class="info file-size">' + imageData.size + '</div></div><hr/></div>' +

                    '</div>';
                $('#Files').append(RowInfo);
                // add file to validate files to upload as json key value
                uploader.multiple.ValidatedFiles[fileName] = imageData.OriginalFile;
                uploader.multiple.imageListManager.count++;
                uploader.multiple.imageListManager.lastIndex++;
            }
      
        },
        removeImage: (imageName) => {
            var currentImageInfo = $('#'+imageName);
            if ($(currentImageInfo).attr("source") == "server")
            {
                swal({
                    title: 'این تصویر حذف شود؟',
                    text: 'در صورت تایید، تصویر ذخیره شده حذف خواهد شد',
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: 'بله',
                    cancelButtonText: 'خیر',
                    closeOnConfirm: false,
                    closeOnCancel: true
                }, function (isConfirm) {
                    if (!isConfirm) return;
                    $.ajax({
                        url: '/user/advertisment/removePicture?' + $.param({ "name": imageName, advertismentId: $('#Advertisment_Id').val() }), //Server script to process data
                        type: 'DELETE',
                        beforeSend: function () {
                            $('button[class=confirm], button[class=cancel]').attr('disabled', 'true');
                        },
                        success: function (timeboxes) {
                            $('.nav-tabs a[href="#tab_15_3"]').tab('show');
                            swal.close();
                            currentImageInfo.hide('slow', function () { currentImageInfo.remove(); });
                        },
                        complete: () => {
                            $('.nav-tabs a[href="#tab_15_3"]').tab('show');
                        },
                    });
                    });
            }
            else {
                delete uploader.multiple.ValidatedFiles[imageName];
                currentImageInfo.hide('slow', function () { currentImageInfo.remove(); });
            }
            uploader.multiple.imageListManager.count--;
        },
    },
    selectedFiles: {},
    DataURLFileReader: {
        read: function(file, callback) {
            let reader = new FileReader();
            let fileInfo = {
                name: file.name,
                type: file.type,
                fileContent: null,
                size: function() {
                    let FileSize = 0;
                    if (file.size > 1048576) {
                        FileSize = Math.round(file.size * 100 / 1048576) / 100 + " MB";
                    } else if (file.size > 1024) {
                        FileSize = Math.round(file.size * 100 / 1024) / 100 + " KB";
                    } else {
                        FileSize = file.size + " bytes";
                    }
                    return FileSize;
                }
            };
            if (!file.type.match('image.*')) {
                callback("فایل انتخاب شده مجاز نیست", fileInfo);
                return;
            }
            reader.onload = function() {
                fileInfo.fileContent = reader.result;
                callback(null, fileInfo);
            };
            reader.onerror = function() {
                callback(reader.error, fileInfo);
            };
            reader.readAsDataURL(file);
        }
    },

    Init_Multiple_Upload: function() {
        $("#UploadedFiles").change(function(evt) {
            uploader.multiple.MultiplefileSelected(evt);
        });
     
        let dropZone = document.getElementById('drop_zone');
        dropZone.addEventListener('dragover', uploader.multiple.handleDragOver, false);
        dropZone.addEventListener('drop', uploader.multiple.MultiplefileSelected, false);
        dropZone.addEventListener('dragenter', uploader.multiple.dragenterHandler, false);
        dropZone.addEventListener('dragleave', uploader.multiple.dragleaveHandler, false);

    },
    ValidatedFiles: {},
    MultiplefileSelected: function(evt) {
        evt.stopPropagation();
        evt.preventDefault();
        $('#drop_zone').removeClass('hover');
        uploader.multiple.selectedFiles = evt.target.files || evt.dataTransfer.files;
        if (uploader.multiple.selectedFiles) {
            //  $('#Files').empty();
            for (let i = 0; i < uploader.multiple.selectedFiles.length; i++) {
                uploader.multiple.DataURLFileReader.read(uploader.multiple.selectedFiles[i], function (err, fileInfo) {
                    if (err != null) {
                        let RowInfo = '<div id="File_' + i + '" class="info"><div class="InfoContainer">' +
                            '<div class="Error">' + err + '</div>' +
                            '<div  class="detail" >' +
                            '<div data-name="FileName" class="info">' + fileInfo.name + '</div>' +
                            '<div data-type="FileType" class="info">' + fileInfo.type + '</div>' +
                            '<div data-size="FileSize" class="info">' + fileInfo.size() + '</div></div><hr/></div>' +
                            '</div>';
                        $('#Files').append(RowInfo);
                    } else {
                        uploader.multiple.imageListManager.addImage({OriginalFile: uploader.multiple.selectedFiles[i] ,fileContent : fileInfo.fileContent, name: fileInfo.name, type: fileInfo.type, size: fileInfo.size() });
                    }
                });
            }
        }
    },

    UploadMultipleFiles: function () {
        if (Object.keys(uploader.multiple.ValidatedFiles).length == 0)
            return false;
        zw.ui.showMessage('', zw.strings.sendingImages, 'info');
        // here we will create FormData manually to prevent sending mon image files 
        let dataString = new FormData();
        //let files = document.getElementById("UploadedFiles").files;
        dataString.append("advertismentId", $('#Advertisment_Id').val());

        Object.keys(uploader.multiple.ValidatedFiles).forEach(function (key) {
            dataString.append("uploadedFiles", uploader.multiple.ValidatedFiles[key]);
        });

        $.ajax({
            url: '/user/advertisment/UplodMultiple', //Server script to process data
            type: 'POST',
            xhr: function() { // Custom XMLHttpRequest
                let myXhr = $.ajaxSettings.xhr();
                if (myXhr.upload) { // Check if upload property exists
                    myXhr.upload.addEventListener('progress', uploader.progressHandlingFunction, false); // For handling the progress of the upload
                }
                return myXhr;
            },
            //Ajax events

            success: uploader.successHandler,
            error: uploader.errorHandler,
            complete: uploader.completeHandler,
            // Form data
            data: dataString,
            //Options to tell jQuery not to process data or worry about content-type.
            cache: false,
            contentType: false,
            processData: false
        });

    },


// Drag and Drop Events
    handleDragOver: function(evt) {
        evt.preventDefault();
        evt.dataTransfer.effectAllowed = 'copy';
        evt.dataTransfer.dropEffect = 'copy';
    },

    dragenterHandler: function() {
        //$('#drop_zone').removeClass('drop_zone');
        $('#drop_zone').addClass('hover');
    },

    dragleaveHandler: function() {
        $('#drop_zone').removeClass('hover');
    },

};