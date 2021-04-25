let uploader = {
    progressHandlingFunction: function(e) {
        if (e.lengthComputable) {
            let percentComplete = Math.round(e.loaded * 100 / e.total);
            $("#FileProgress").css("width", percentComplete + '%').attr('aria-valuenow', percentComplete);
            $('#FileProgress span').text(percentComplete + "%");
        } else {
            $('#FileProgress span').text('unable to compute');
        }
    },

    completeHandler: function() {
        //$('#createView').empty();
        //$('.CreateLink').show();
        //$.unblockUI();
    },


    successHandler: function(data) {
        if (data.statusCode == 200) {
            $('.nav-tabs a[href="#tab_15_3"]').tab('show');
            $('#Files').children().remove();
            uploader.multiple.imageListManager.lastIndex = 0;
            uploader.multiple.imageListManager.count = 0;
            uploader.multiple.ValidatedFiles = {};

            // clear input file to notify change and fire event
            var $el = $('#UploadedFiles');
            $el.wrap('<form>').closest('form').get(0).reset();
            $el.unwrap();
            // end clear input

            for (var key in data.pictures)
            {
                uploader.multiple.imageListManager.addImage({ name: data.pictures[key], source: 'server' });
            }
          //  alert(data.status);
            zw.ui.showMessage('', 'تصاویر ارسال شد', 'info');
            zw.ui.showMessage('', 'آگهی با موفقیت ثبت شد', 'info');
        } else if (data.statusCode == 201)
        {
            // do nothing
            // there is no image uploaded
        }
        else {
            alert(data.status);
        }
    },

    errorHandler: function(xhr, ajaxOptions, thrownError) {
      //  alert("خطا در ارسال تصاویر. (" + thrownError + ")");
        zw.ui.showMessage('', 'خطا در ارسال تصاویر، لطفا مجددا سعی کنید', 'error');
    },

    OnDeleteAttachmentSuccess: function(data) {

        if (data.ID && data.ID != "") {
            $('#Attachment_' + data.ID).fadeOut('slow');
        } else {
            alter("Unable to Delete");
            console.log(data.message);
        }
    },

    Cancel_btn_handler: function() {
        //$('#createView').empty();
        //$('.CreateLink').show();
        //$.unblockUI();
    }

}