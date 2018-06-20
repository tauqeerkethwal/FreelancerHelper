

$(function () {
    $('input[class=WeekCheckbox]').click(function () {
        checkboxValidation(this);
    })
});

$(document).ready(function () {
  
    $("#weekModel_EvenWeekHours").focusout(function () {
        if($("#weekModel_Every2ndWeekHours").val().length==0)
            $("#weekModel_Every2ndWeekHours").val($("#weekModel_EvenWeekHours").val());
        if ($("#weekModel_Every4thWeekHours").val().length == 0)
        $("#weekModel_Every4thWeekHours").val($("#weekModel_EvenWeekHours").val());
    });
    $("#weekModel_OddWeekHours").focusout(function () {
        if ($("#weekModel_Every1stWeekHours").val().length == 0)
            $("#weekModel_Every1stWeekHours").val($("#weekModel_OddWeekHours").val());
        if ($("#weekModel_Every3rdWeekHours").val().length == 0)
            $("#weekModel_Every3rdWeekHours").val($("#weekModel_OddWeekHours").val());
        if ($("#weekModel_Every5thWeekHours").val().length == 0)
        $("#weekModel_Every5thWeekHours").val($("#weekModel_OddWeekHours").val());
    });
    if ($("#weekModel_EveryWeek").is(':checked')) {
        checkboxValidation('#weekModel_EveryWeek');
    }
    else if ($("#weekModel_EvenWeek").is(':checked')) {
        debugger
        checkboxValidation('#weekModel_EvenWeek');
    }
    else
        if ($("#weekModel_OddWeek").is(':checked')) {
            debugger
            checkboxValidation('#weekModel_OddWeek');
        }
        else
            ShowAlldiv();


});

function hideAlldiv() {
    $('[name="EveryWeek"]').hide();
    $('[name="EvenWeek"]').hide();
    $('[name="OddWeek"]').hide();
    $('[name="Every1stWeek"]').hide();
    $('[name="Every2ndWeek"]').hide();
    $('[name="Every3rdWeek"]').hide();
    $('[name="Every4thWeek"]').hide();
    $('[name="Every5thWeek"]').hide();
    $('[name="EveryLastWeek"]').hide();

}
function showthidiv(thisdiv) {

    $('[name="' + thisdiv + '"]').show();
}
function ShowAlldiv() {
    $('[name="EveryWeek"]').show();
    $('[name="EvenWeek"]').show();
    $('[name="OddWeek"]').show();
    $('[name="Every1stWeek"]').show();
    $('[name="Every2ndWeek"]').show();
    $('[name="Every3rdWeek"]').show();
    $('[name="Every4thWeek"]').show();
    $('[name="Every5thWeek"]').show();
    $('[name="EveryLastWeek"]').show();

}

function checkboxValidation(selector) {
    debugger
    if ($(selector).is(':checked')) {
        if ($(selector).attr('name') == "weekModel.EveryWeek") {
            $('input[class=WeekCheckbox]').attr('disabled', true);
            $('input[class=WeekCheckbox]').prop('checked', false);
            $('input[class=WeekCheckbox]').val('false');
            $('input[class=hiddencheckbox]').val('false');
            
            $(selector).prop("disabled", false);;
            $(selector).prop('checked', true);
            $(selector).val('true');
            hideAlldiv();
            showthidiv("EveryWeek")
        }
        else
            if ($(selector).attr('name') == "weekModel.EvenWeek") {
                $('input[class=WeekCheckbox]').attr('disabled', true);
                $('input[class=WeekCheckbox]').prop('checked', false);
                $('input[class=hiddencheckbox]').val('false');
                $(selector).prop("disabled", false);
                $(selector).prop('checked', true);
                $(selector).val('true');
                $("#weekModel_Every4thWeek").attr("disabled", true);
                $('input[name="weekModel.Every4thWeek"]').prop('value', true);
                $("#weekModel_Every4thWeek").prop('checked', true);
                $("#weekModel_Every2ndWeek").attr("disabled", true);
                $('input[name="weekModel.Every2ndWeek"]').prop('value',true);
                $("#weekModel_Every2ndWeek").prop('checked', true);
                hideAlldiv();
                showthidiv("EvenWeek");
                showthidiv("Every2ndWeek");
                showthidiv("Every4thWeek");
            }
            else
                if ($(selector).attr('name') == "weekModel.OddWeek") {
                    $('input[class=WeekCheckbox]').attr('disabled', true);
                    $('input[class=WeekCheckbox]').prop('checked', false);
                    $('input[class=hiddencheckbox]').val('false');
                    $(selector).attr("disabled", false);
                    $(selector).prop('checked', true);
                    $("#weekModel_Every1stWeek").attr("disabled", true);
                    $('input[name="weekModel.Every1stWeek"]').prop('value', true);
                    $("#weekModel_Every1stWeek").prop('checked', true);
                    $("#weekModel_Every3rdWeek").attr("disabled", true);
                    $('input[name="weekModel.Every3rdWeek"]').prop('value', true);
                    $("#weekModel_Every3rdWeek").prop('checked', true);
                    $("#weekModel_Every5thWeek").attr("disabled", true);
                    $('input[name="weekModel.Every5thWeek"]').prop('value', true);
                    $("#weekModel_Every5thWeek").prop('checked', true);
                    hideAlldiv();
                    showthidiv("OddWeek");
                    showthidiv("Every1stWeek");
                    showthidiv("Every3rdWeek");
                    showthidiv("Every5thWeek");
                }


    }
    else {
        $('input[class=WeekCheckbox]').prop("disabled", false);;;
        $('input[class=WeekCheckbox]').prop('checked', false);
        $('input[class="hiddencheckbox"]').val('false');
        ShowAlldiv();
    }
}

$(function () {
    $('input[class=WeekCheckbox]').click(function () {
        checkboxValidation(this);
    })
});

                                                  function CheckWeekValidation(WeekType) {

                                                      var check = true;
                                                      var Weeks = ["EveryWeek", "EvenWeek", "OddWeek", "Every1stWeek", "Every2ndWeek", "Every3rdWeek", "Every4thWeek", "Every5thWeek", "EveryLastWeek"];
                                                   
                                                      for (i = 0; i < Weeks.length; i++) {
                                                          if ($('#' + WeekType + "_" + Weeks[i]).prop('checked')) {
                                                              if ($("#" + WeekType + "_" + Weeks[i] + "Hours").val().length == 0) {
                                                                  $("#" + WeekType + "_" + Weeks[i] + "Hours").css('border-color', 'red');
                                                                  check = false;
                                                              }
                                                              else {
                                                                  $("#" + WeekType + "_" + Weeks[i] + "Hours").css('border-color', '#d2d6de');
                                                              }

                                                              if ($("#" + WeekType + "_" + Weeks[i] + "Hours").val() <= 0) {
                                                                  $("#" + WeekType + "_" + Weeks[i] + "Hours").css('border-color', 'red');
                                                                  check = false;
                                                              }
                                                              else {
                                                                  $("#" + WeekType + "_" + Weeks[i] + "Hours").css('border-color', '#d2d6de');
                                                              }
                                                               
                                                               

                                                          }
                                                          else {
                                                              $("#" + WeekType + "_" + Weeks[i] + "Hours").css('border-color', '#d2d6de');
                                                          }
                                                             
                                                      }
                                                      return check;
                                                  }
function CheckDaysValidation(DaysType) {

    var check = true;
    var days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];

    for (i = 0; i < days.length; i++) {
        if ($('#' + DaysType + "_" + days[i]).prop('checked')) {
            if ($("#" + DaysType + "_" + days[i] + "StartTime").val().length < 5) {
                $("#" + DaysType + "_" + days[i] + "StartTime").css('border-color', 'red');
                check = false;
                break;
            }
            else {
                $("#" + DaysType + "_" + days[i] + "StartTime").css('border-color', '#d2d6de');
            }
            if ($("#" + DaysType + "_" + days[i] + "EndTime").val().length < 5) {
                $("#" + DaysType + "_" + days[i] + "EndTime").css('border-color', 'red');
                check = false;
                break;
            }
            else {
                $("#" + DaysType + "_" + days[i] + "EndTime").css('border-color', '#d2d6de');
            }
            if ($("#" + DaysType + "_" + days[i] + "StartTime").val().substring(0, 5) == $("#" + DaysType + "_" + days[i] + "EndTime").val().substring(0, 5)) {
                $("#" + DaysType + "_" + days[i] + "EndTime").css('border-color', 'red');
                $("#" + DaysType + "_" + days[i] + "StartTime").css('border-color', 'red');
                check = false;
            }
            else {
                $("#" + DaysType + "_" + days[i] + "EndTime").css('border-color', '#d2d6de');
                $("#" + DaysType + "_" + days[i] + "StartTime").css('border-color', '#d2d6de');

            }
            if (((new Date("1970-1-1 " + $("#" + DaysType + "_" + days[i] + "EndTime").val()) - new Date("1970-1-1 " + $("#" + DaysType + "_" + days[i] + "StartTime").val().substring(0, 5))) / 1000 / 60) <= 0) {
                $("#" + DaysType + "_" + days[i] + "EndTime").css('border-color', 'red');
                $("#" + DaysType + "_" + days[i] + "StartTime").css('border-color', 'red');
                check = false;
            }
            else {
                $("#" + DaysType + "_" + days[i] + "EndTime").css('border-color', '#d2d6de');
                $("#" + DaysType + "_" + days[i] + "StartTime").css('border-color', '#d2d6de');

            }


        }
                                                         
    }
    return check;
}
function CheckEmployeeExist() {
    if ($("#ScheduleEmployees0").length == 0)
    {
        alert("Must select atleast 1 employee");

    }
    return $("#ScheduleEmployees0").length > 0;
}

function ValidateScheduler(event){
    var validated = true;
    if (!CheckEmployeeExist())
        validated = false;
    //if (!CheckDaysValidation("NormalDays"))
    //    validated = false;
    //if (!CheckDaysValidation("WishDays"))
    //    validated = false;
    if (!CheckWeekValidation("weekModel"))
        validated = false;
                                                        
    if(!validated)
        event.preventDefault();
        
}

