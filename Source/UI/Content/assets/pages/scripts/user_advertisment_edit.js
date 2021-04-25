$(function() {
    uploader.multiple.Init_Multiple_Upload();
    zw.page.initialize();
    currency_auto_formatter.bind($('#PriceValue'));
});

zw.page = {
    strings: {
        enterTitle: 'عنوان آگهی الزامی است',
        enterPrice:'مبلغ آگهی الزامی است',
        operationCanceled: 'عملیات لغو شد',
        fileIsNotPicture: 'فایل انتخاب شده یک تصویر نیست. لطفا یک تصویر انتخاب کنید.',
        contentNotSavedMessage: 'تغییرات شما ذخیره نشده است. آیا این صفحه را ترک می کنید؟',
        uploadFinished: 'آپلود فایل به اتمام رسید',
        correctInvalidInput: 'اطلاعات ورودی را اصلاح نمایید',
        errorOnSave: 'خطا!',
        errorOnLoadingPictures: 'خطا در بازخوانی تصاویر',
        afterSave:'آگهی بعد از تایید نمایش داده خواهد شد'
    },
    mediaPopup: null,

    initialize: function () {
        if ($('#PageMode').val() == "Edit") {
            zw.page.loadAdvertismentPictures();
        }
        $('form').submit(false);
    },

    onSaveClick: function() {
        var pageData = this.getPageData();
        if (!this.validateForm(pageData)) {
            zw.ui.showMessage(zw.page.strings.correctInvalidInput, zw.page.strings.errorOnSave, 'error');
            return;
        }

        this.save(
            pageData,
            function(response) {
            },
            function() {
            });
    },

    save: function(pageData, successCallback, errorCallback) {
        $.ajax('/user/advertisment/save', {
            method: 'POST',
            data: pageData,
            beforeSend: function() {
                $('.save-button, .preview-button').addClass('disabled');
                zw.ui.showMessage('', zw.strings.saving, 'info');
            },
            success: function(response) {
                $('#Advertisment_Id').val(response.Data.AdvertismentId);
                $('#PageMode').val("Edit");
                zw.ui.showMessage('', zw.strings.saved, 'info');
                zw.ui.showMessage('', zw.page.strings.afterSave, 'info');
                zw.page.startUploadImages();
                successCallback(response);
            },
            complete: function (response) {
   
                $('.save-button, .preview-button').removeClass('disabled');
            },
            error: function(response) {
                errorCallback(response);
            }
        });
    },

    validateForm: function (pageData) {
        var validator = $('#mainForm').validate();
        validator.form();
        var isValidForm = validator.valid();
        if (!isValidForm) return false;
        if (validator.valid()) {
            if (pageData.Title == '') {
                zw.ui.showMessage(zw.page.strings.enterTitle, '', 'error', true);
                return false;
            }
            else if (pageData.Price == '') {
                zw.ui.showMessage(zw.page.strings.enterPrice, '', 'error', true);
                return false;
            }
        }
        return true;
    },

    getPageData: function() {
        let pageData = {
            Id: $('#Advertisment_Id').val(),
            Title: $('#Title').val(),
            Comment: $('#Comment').val(),
            TypeIdentity: $("#AdvertismentTypeName").val(),
            Model: $('#Model').val(),
            Country: $('#Country').val(),
            ManufacturingCountry: $('#ManufacturingCountry').val(),
            ConstructionYear: $('#ConstructionYear').val(),
            Height: $('#Height').val(),
            Width: $('#Width').val(),
            Length: $('#Length').val(),
            Wieght: $('#Wieght').val(),
            HealthStatus: $('#HealthStatus').val(),
            MaxWorkPieceWeight: $('#MaxWorkPieceWeight').val(),
            PriceValue: $('#PriceValue').val().toEnglishNumber(),
            PageMode: $('#PageMode').val(),
            AdvertismentTypeName: $("#AdvertismentTypeName").val(),
            AdvertiserNote: $("#AdvertiserNote").val()
        };
        zw.page.appendTypeSpecificData(pageData);
        return pageData;
    },
    appendTypeSpecificData: function (baseData) {
        switch (baseData.AdvertismentTypeName) {
            // normal lathe
            case "NormalLathe":
                baseData.RailsArePlated = $('#RailsArePlated').val();
                baseData.HasRulerAndViewer = $('#HasRulerAndViewer').val();
                baseData.RulerMark = $('#RulerMark').val();
                baseData.HasMorghak = $('#HasMorghak').val();
                baseData.MorghakDiagonal = $('#MorghakDiagonal').val();
                baseData.MorghakDisplacementLength = $('#MorghakDisplacementLength').val();
                baseData.HasLapent = $('#HasLapent').val();
                baseData.MaximumBorderDiameter = $('#MaximumBorderDiameter').val();
                baseData.MaximumDiameter = $('#MaximumDiameter').val();
                baseData.BedWidth = $('#BedWidth').val();
                baseData.MaximumMachiningLength = $('#MaximumMachiningLength').val();
                baseData.SpindleSpinsNumber = $('#SpindleSpinsNumber').val();
                baseData.SpindleSpinsFrom = $('#SpindleSpinsFrom').val();
                baseData.SpindleSpinsTo = $('#SpindleSpinsTo').val();
                baseData.AxisMovementSpeedFrom = $('#AxisMovementSpeedFrom').val();
                baseData.AxisMovementSpeedTo = $('#AxisMovementSpeedTo').val();
                baseData.MetricScrewFrom = $('#MetricScrewFrom').val();
                baseData.MetricScrewTo = $('#MetricScrewTo').val();
                baseData.InkyScrewFrom = $('#InkyScrewFrom').val();
                baseData.InkyScrewTo = $('#InkyScrewTo').val();
                baseData.HasSoapAndWaterSystem = $('#HasSoapAndWaterSystem').val();
                baseData.HasThreeOrder = $('#HasThreeOrder').val();
                baseData.ThreeOrderDiameter = $('#ThreeOrderDiameter').val();
                baseData.HasFourOrder = $('#HasFourOrder').val();
                baseData.FourOrderDiameter = $('#FourOrderDiameter').val();
                baseData.HasLift = $('#HasLift').val();
                break;
            case "CncLathe":
                baseData.ControlStatus = $('#ControlStatus').val();
                baseData.LatheType = $('#LatheType').val();
                baseData.RailType = $('#RailType').val();
                baseData.HasXAxis = $('#HasXAxis').val();
                baseData.XAxisMovementFeed = $('#XAxisMovementFeed').val();
                baseData.XAxisTableType = $('#XAxisTableType').val();
                baseData.XAxisSpeed = $('#XAxisSpeed').val();
                baseData.HasYAxis = $('#HasYAxis').val();
                baseData.YAxisMovementFeed = $('#YAxisMovementFeed').val();
                baseData.YAxisTableType = $('#YAxisTableType').val();
                baseData.YAxisSpeed = $('#YAxisSpeed').val();
                baseData.HasZAxis = $('#HasZAxis').val();
                baseData.ZAxisMovementFeed = $('#ZAxisMovementFeed').val();
                baseData.ZAxisTableType = $('#ZAxisTableType').val();
                baseData.ZAxisSpeed = $('#ZAxisSpeed').val();
                baseData.SpindleEnginePower = $('#SpindleEnginePower').val();
                baseData.SpindleRoundPerMinute = $('#SpindleRoundPerMinute').val();
                baseData.SpindleHasGearbox = $('#SpindleHasGearbox').val();
                baseData.HasAcEngine = $('#HasAcEngine').val();
                baseData.HasDcEngine = $('#HasDcEngine').val();
                baseData.HasOtherEngine = $('#HasOtherEngine').val();
                baseData.EngineMarks = $('#EngineMarks').val();
                baseData.DriveMarks = $('#DriveMarks').val();
                baseData.ToolChangerType = $('#ToolChangerType').val();
                baseData.ToolsNumber = $('#ToolsNumber').val();
                baseData.AliveToolsNumber = $('#AliveToolsNumber').val();
                baseData.HasSoapAndWaterSystem = $('#HasSoapAndWaterSystem').val();
                break;
            case "NormalCarousel":
                baseData.MaximumRotationalDiameter = $('#MaximumRotationalDiameter').val();
                baseData.TableDiameter = $('#TableDiameter').val();
                baseData.MaximumHiegh = $('#MaximumHiegh').val();
                baseData.MaximumAllowedLoad = $('#MaximumAllowedLoad').val();
                baseData.TableRotationSpeed = $('#TableRotationSpeed').val();
                baseData.RotationSpeedNumber = $('#RotationSpeedNumber').val();
                baseData.MovementSpeed = $('#MovementSpeed').val();
                baseData.MovementSpeedNumber = $('#MovementSpeedNumber').val();
                baseData.RamHorizontalCourse = $('#RamHorizontalCourse').val();
                baseData.RamVerticalCourse = $('#RamVerticalCourse').val();
                baseData.MainEnginePower = $('#MainEnginePower').val();
                break;
            case "FlatStone":
                baseData.StoneType = $('#StoneType').val();
                baseData.MaximumGrindingWidth = $('#MaximumGrindingWidth').val();
                baseData.MaximumGrindingLength = $('#MaximumGrindingLength').val();
                baseData.MaximumGrindingHeight = $('#MaximumGrindingHeight').val();
                baseData.MaximumAllowedLoad = $('#MaximumAllowedLoad').val();
                baseData.StoneWidth = $('#StoneWidth').val();
                baseData.stoneHeight = $('#stoneHeight').val();
                baseData.SpindleSpeed = $('#SpindleSpeed').val();
                baseData.HydraulicReservoirPressure = $('#HydraulicReservoirPressure').val();
                baseData.HydraulicOilTankCapacity = $('#HydraulicOilTankCapacity').val();
                break;
            case "CncMilling":
                baseData.AxisNumber = $('#AxisNumber').val();
                baseData.TableWidth = $('#TableWidth').val();
                baseData.TableHeight = $('#TableHeight').val();
                baseData.TableType = $('#TableType').val();
                baseData.BodyType = $('#BodyType').val();
                baseData.MainEngingePower = $('#MainEngingePower').val();
                baseData.SpindleGearbox = $('#SpindleGearbox').val();
                baseData.SpindleRound = $('#SpindleRound').val();
                baseData.HasACAxisEngine = $('#HasACAxisEngine').val();
                baseData.HasDCAxisEngine = $('#HasDCAxisEngine').val();
                baseData.EnginesMark = $('#EnginesMark').val();
                baseData.EngineDriversMark = $('#EngineDriversMark').val();
                baseData.HasBalanceWeight = $('#HasBalanceWeight').val();
                baseData.HasHydraulicBalanceSystem = $('#HasHydraulicBalanceSystem').val();
                baseData.ToolsHolderType = $('#ToolsHolderType').val();
                baseData.ToolsCountSimultaneousChange = $('#ToolsCountSimultaneousChange').val();
                baseData.HasSoapWaterSystem = $('#HasSoapWaterSystem').val();
                baseData.HasToolCenterSoapWater = $('#HasToolCenterSoapWater').val();
                baseData.HasFourthAxis = $('#HasFourthAxis').val();
                baseData.HasClamp = $('#HasClamp').val();
                baseData.HasComputer = $('#HasComputer').val();
                baseData.HasAirPump = $('#HasAirPump').val();

                break;
            case "ManualMilling":
                baseData.TableWidth = $('#TableWidth').val();
                baseData.TableHeight = $('#TableHeight').val();
                baseData.XCourse = $('#XCourse').val();
                baseData.XCourseMinSpeed = $('#XCourseMinSpeed').val();
                baseData.XCourseMaxSpeed = $('#XCourseMaxSpeed').val();
                baseData.YCourse = $('#YCourse').val();
                baseData.YCourseMinSpeed = $('#YCourseMinSpeed').val();
                baseData.YCourseMaxSpeed = $('#YCourseMaxSpeed').val();
                baseData.ZCourse = $('#ZCourse').val();
                baseData.ZCourseMinSpeed = $('#ZCourseMinSpeed').val();
                baseData.ZCourseMaxSpeed = $('#ZCourseMaxSpeed').val();
                baseData.HasMeterFunctionality = $('#HasMeterFunctionality').val();
                baseData.LubricationType = $('#LubricationType').val();
                baseData.HasSoapWaterPump = $('#HasSoapWaterPump').val();
                baseData.MillingRailType = $('#MillingRailType').val();
                baseData.RailsHealthStatus = $('#RailsHealthStatus').val();
                baseData.HasLEDLighting = $('#HasLEDLighting').val();
                baseData.HasToolbox = $('#HasToolbox').val();
                baseData.AxisType = $('#AxisType').val();
                baseData.SpindleType = $('#SpindleType').val();
                baseData.SpindleMaxSpeed = $('#SpindleMaxSpeed').val();
                baseData.SpindleMinSpeed = $('#SpindleMinSpeed').val();
                baseData.HasDrillCapability = $('#HasDrillCapability').val();
                baseData.HasRulerAndDRO = $('#HasRulerAndDRO').val();
                baseData.HasClamp = $('#HasClamp').val();
                break;
            case "Drill":
                baseData.DrillType = $('#DrillType').val();
                baseData.DiameterDrillMaxAllowed = $('#DiameterDrillMaxAllowed').val();
                baseData.Morse = $('#Morse').val();
                baseData.MaxDistanceFromColumn = $('#MaxDistanceFromColumn').val();
                baseData.MaxDistanceFromTable = $('#MaxDistanceFromTable').val();
                baseData.TableWidth = $('#TableWidth').val();
                baseData.TableHeight = $('#TableHeight').val();
                baseData.NumberOfSpindleSpeeds = $('#NumberOfSpindleSpeeds').val();
                baseData.GearboxType = $('#GearboxType').val();
                baseData.MillerCapability = $('#MillerCapability').val();
                baseData.HoleType = $('#HoleType').val();
                baseData.ColumnHeadDiameter = $('#ColumnHeadDiameter').val();
                baseData.RotatingTable = $('#RotatingTable').val();
                baseData.TableMaxRotation = $('#TableMaxRotation').val();
                baseData.CoolingPump = $('#CoolingPump').val();
                break;
        }
    },
    startUploadImages: function () {
        // call uploader to upload files
        uploader.multiple.UploadMultipleFiles();
    },
    loadAdvertismentPictures: function () {
        $.ajax({
            url: '/User/Advertisment/GetAdvertismentPictures',
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8', //define a contentType of your request
            cache: false,
            data: { advertismentId: $('#Advertisment_Id').val() },
            success: function (data) {
                for (var key in data.pictures) {
                    uploader.multiple.imageListManager.addImage({ name: data.pictures[key], source: 'server' });
                }
            },
            error: function (error) {
                zw.ui.showMessage(zw.page.strings.errorOnLoadingPictures, zw.page.strings.errorOnSave, 'error');
            }
        }); 
      
    }
}
