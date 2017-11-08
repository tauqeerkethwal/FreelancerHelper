
                                                  function CheckWeekValidation(WeekType) {

                                                      var check = true;
                                                      var Weeks = ["EveryWeek", "EvenWeek", "OddWeek", "Every1stWeek", "Every2ndWeek", "Every3rdWeek", "Every4thWeek ", "Every5thWeek ", "EveryLastWeek"];

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
    if (!CheckDaysValidation("NormalDays"))
        validated = false;
    if (!CheckDaysValidation("WishDays"))
        validated = false;
    if (!CheckWeekValidation("weekModel"))
        validated = false;
                                                        
    if(!validated)
        event.preventDefault();
        
}
