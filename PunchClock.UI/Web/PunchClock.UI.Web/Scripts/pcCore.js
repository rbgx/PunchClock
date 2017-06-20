﻿/// <reference path="jquery.inputmask/inputmask.js" />

function postUpdateUser(e) {
    if (e.user.Uid > 0) {
        showDialog("Update Successful",
            "You have successfully update user information.",
            "400px",
            "300px");
    }
    else if (e.user.Uid < 1) {
        showDialog("Update Failed",
           "Unfortunately we could not complete your request at this point of time. If this continue to happen again, please contact support team.",
           "400px",
           "300px");
    }
}
function postResponseRegistration(e) {
    if (e.Uid === -3) {
        showDialog("User Name not available",
            "The User Name you have requested is not available. Please enter a different User Name and submit.",
            "400px",
            "300px");
    }
    else if (e.Uid === -2) {
        showDialog("Invalid",
           "The registration code you have entered is invalid. Please check if you have entered the right code.",
           "400px",
           "300px");
    }
    else if (e.Uid > 0 && e.userTypeId === 2) {
        showDialog("Success",
          "Your account has been successfully created. Please wait until you receive an email with an activation message.",
          "400px",
          "300px");
    }
    else if (e.Uid === -4)
    {
        showDialog("Duplicate Company",
          "The Company Which is Entered is Already Register.",
          "400px",
          "300px");
    }
    else if (e.Uid > 0) {
        window.location.href = "/";
    }
    console.log(e.Uid);
}

$(function () {

    //$("#menu").kendoMenu().css({
    //    width: "550px"
    //    //marginRight: "220px"
    //});

    //$("select").kendoDropDownList();
    
    //$("input[type='text']").addClass("k-textbox");
    //$("textarea").addClass("k-textbox");
    //$("input[type='number']").addClass("k-textbox");
    //$("input[type='email']").addClass("k-textbox");
    //$("input[type='password']").addClass("k-textbox");
    //$("input[type='file']").addClass("k-textbox");

    $('#loadingDiv')
    .hide()  // hide it initially
    .ajaxStart(function () {
        $(this).show();
    })
    .ajaxStop(function () {
        $(this).hide();
    })    ;
});



function showDialog(strTitle, strContent, pxWidth, pxHeight) {
    var $window = $("#kwDialog");
    $window.kendoWindow({
        width: pxWidth,
        title: strTitle,
        modal: true,
        actions: [
            "Pin",
            "Minimize",
            "Maximize",
            "Close"
        ],
        close: onClose
    });
    var $kwContent = $window.data("kendoWindow");
    $kwContent.content(strContent);
    $kwContent.center();
    $kwContent.open();

    var onClose = function () {
        $kwContent.content("");
    }
}


$(function () {
    $("#reqDifferentTime").click(function (e) {
        //min: new Date($(".UTCDate").text() + $(".UTCTime").text())
        var pOutDate = new Date($(".UTCDate").text() + " " + $(".UTCTime").text());
        var d = new Date();
        if ($(this).is(":checked")) {
            $pTime = $(".pTime");
           // $pTime.inputmask("99:99 aa");
            $pTime.show().attr("required", "required");
            if (!$pTime.parent().hasClass("k-picker-wrap")) {
                if ($pTime.attr("id") == "pTimePunchOut") {
                    $pTime.kendoTimePicker({
                        format: "hh:mm tt",
                        min: new Date(pOutDate.getFullYear(), pOutDate.getMonth() + 1, pOutDate.getDay(), pOutDate.getHours() + 1, 0, 0),
                        max: new Date(pOutDate.getFullYear(), pOutDate.getMonth() + 1, pOutDate.getDay(), pOutDate.getHours() + 9, 0, 0)
                    });
                }
                else if ($pTime.attr("id") == "pTimePunchIn") {
                    $pTime.kendoTimePicker({
                        format: "hh:mm tt",
                        min: new Date(d.getFullYear(), d.getMonth() + 1, d.getDay(), d.getHours() - 2, 0, 0),
                        max: new Date(d.getFullYear(), d.getMonth() + 1, d.getDay(), d.getHours() + 2, 0, 0)
                    });
                }
            }
           
        }
        else {
            $(".pTime").removeAttr("required").hide();
        }
    });
   
    $(".pDate").kendoDatePicker();

    $(".pTime").keypress(function (e) {
        //validateTime(this);
    });
    function validateTime($this) {
        var time = $($this).val();
        time = time.replace(/_/g, "").replace(":", "");
        //console.log(time);
        //console.log(time.substr(0, 2))
        var isValid = true;
        if (time.length > 0) {
            if (time.length >= 2) {
                var hour = parseInt(time.substr(0, 2), 10);
                //console.log(hour);
                if (hour >= 0 && hour <= 24) {

                }
                else {
                    $($this).val("");
                    alert("Invalid Hour");
                }
            }
            if (time.length >= 4) {
                var minute = parseInt(time.substr(2, 2), 10);
                //console.log(minute);
                if (minute >= 0 && minute <= 60) {

                }
                else {
                    $($this).val("");
                    alert("Invalid Minutes");
                }
            }

            if (time.length >= 6) {
                var AMPM = time.substr(4, 2);
               // console.log(AMPM);
                if (AMPM.toLowerCase() == "am" || AMPM.toLowerCase() == "pm") {

                }
                else {
                    $($this).val("");
                    alert("Invalid AM PM");
                }
            }
        }
    }

    $("button.punchCompleteMessage").click(function () {
        window.location ="/";
    })

    function punchCompleteMessage() {

    }
    $(".resultGridSection").hide();
    $(".ckdPunchReport").on("click", function (e) {
        // console.log(this.value);
        if (this.value == "1") {
            $("#stDate").val("").removeAttr("required");
            $("#enDate").val("").removeAttr("required");
            $(".field-validation-error").addClass("field-validation-valid").removeClass("field-validation-error")
        }
        else if (this.value == "2") {
            $("#stDate").val("").attr("required", "required");
            $("#enDate").val("").attr("required", "required");
        }
    });
    $(".reportDate").blur(function () {
        var inputValue = $(this).val();
        if (inputValue === null || inputValue === undefined || inputValue.length === 0) {
            $(this).val("");
            $(this).focus();
            return;
        }
        var d = new Date($(this).val());
        if (isNaN(d.getTime())) {
            alert($(this).val() + "is not a valid date.\nPlease enter valid date");
            $(this).val("");
        }
        else {
            $(this).removeAttr("required");
        }
    })

    
});

    $(function () {
        var d = new Date();
        var offsetms = d.getTimezoneOffset() * 60 * 1000;
        $('.UTCTime').each(function () {
            try
            {
                var text = $(this).text();
                var timeArray = String(text).split(':');
                var currentDate = new Date();

                var n = new Date(currentDate.getFullYear(), currentDate.getMonth()+1, currentDate.getDay(), timeArray[0], timeArray[1], timeArray[2], 00);
                n = new Date(n.valueOf() - offsetms);
                //n.toDateString() + " " +
                $(this).text(n.toLocaleTimeString());
                $(this).attr("value", text);
            }
            catch (ex) {
                console.warn("Error converting time", ex);
            }
        });
        utcDate();
    });

    function utcDate() {
       // console.log("I am here");
        $('.UTCDate').each(function () {
            try {
                var text = $(this).text();

                var n = new Date(text);
                n = new Date(n.valueOf() - offsetms);
                //n.toDateString() + " " +
                $(this).text(n.toDateString());
                $(this).attr("value", text);
            }
            catch (ex) {
                console.warn("Error converting date", ex);
            }
        });
    }

    function UTCToClientLocal(timeSpan) {
        var d = new Date();
        var offsetms = d.getTimezoneOffset() * 60 * 1000;
        try {
            var text = timeSpan;
            var timeArray = String(text).split(':');
            var currentDate = new Date();

            var n = new Date(currentDate.getFullYear(), currentDate.getMonth() + 1, currentDate.getDay(), timeArray[0], timeArray[1], timeArray[2], 00);
            n = new Date(n.valueOf() - offsetms);
            return n.toLocaleTimeString();
        }
        catch (ex) {
            console.warn("Error converting time", ex);
        }
        return timeSpan;
    }

    function UTCDateToClientLocalDate(punchDate) {
        //console.log(punchDate);
        var dbDate = new Date(parseInt(punchDate.substr(6)));
        //console.log(dbDate);

        var timeOffset = -((new Date()).getTimezoneOffset() / 60);
        dbDate.setHours(dbDate.getHours() + timeOffset);
        console.log(dbDate);
        return dbDate.toLocaleString();
    }

    function DateToUTC(punchDate) {
        //console.log(punchDate);
        var dbDate = new Date(parseInt(punchDate.substr(6)));
        console.log(dbDate.toISOString());
        return dbDate.toISOString();
    }

    function DayFromDate(jsonDate) {
        var date = new Date(parseInt(jsonDate.substr(6)));
        var day = date.getDayName();
        //console.log(day);
        return day;
    }

    function MinutesToTime(secs) {
        //console.log(secs);
        var hr = Math.floor(secs / 3600);
        var min = Math.floor((secs - (hr * 3600)) / 60);
        var sec = secs - (hr * 3600) - (min * 60);

        while (String(hr).length < 2) { hr = '0' + hr; }
        while (String(min).length < 2) { min = '0' + min; }
        while (String(sec).length < 2) { sec = '0' + sec; }
        if (hr) hr += ':';
        else hr = "00:";
        if (!min) min = "00";
        if (!sec) sec = "00";
        return hr + min + ':' + sec;
    }

    function computeHoursRange(data) {
        var totalHours = MinutesToTime(data);
        //console.log(totalHours);
        $("#totalHours").html(totalHours);
        return totalHours;
    }

    function updateResponse(d) {
        // alert("sssss");
        $(".k-pager-refresh").trigger("click");
        if (d.isSuccess == true) {
            //alert("Success");
           // $(".k-pager-refresh").trigger("click");
        }
    }

    function postResponseUpdate(e) {
        showDialog("Success",
         "Your have successfully updated employee information.",
         "400px",
         "300px");
    }
        
  
    (function () {
        var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];

        var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

        Date.prototype.getMonthName = function () {
            return months[this.getMonth()];
        };
        Date.prototype.getDayName = function () {
            return days[this.getDay()];
        };
    })();

function appSettingEditable(dataItem) {
    // do not allow editing for product with ProductID=3
    return dataItem.IsEditable;
}