var commonTolkDanmark = new function () {


    this.CheckLastChangedOrder = function (orderId, data) {

        if (LAST_CHANGED_ORDER_ID == orderId) {
            return "<div style='background:#A0522D; color:White; padding:4px;'>" + data + "</div>"
        }

        return data;
    };

    this.CitizenNameColor = function (orderTypeId) {
        var style = '';
        if (orderTypeId == 6) {
            style = "style='background:#ff6666'";
        }
        else if (orderTypeId == 3) {
            style = "style='background:#FFA500'";
        }
        else {
            style = '';
        }
        return style;
    };



    this.getEmployeeDeletedColorCode = function (full) {
        //         debugger;
        var html = "";
        switch (full.del) {
            case true:

                html += "<div title='Deleted' style=' background-color:#FF1434;  '></div>";
                break;
            case false:
                html += "<div title='Deleted' style=' background-color:#6FB76F;  '></div>";
                break;

        }
        return html;

    };
    this.getEmployeeActiveColorCode = function (full) {
        //         debugger;
        var html = "";
        switch (full.Active) {
            case false:

                html += "<div title='Deleted' style=' background-color:#FF1434;  '></div>";
                break;
            case true:
                html += "<div title='Deleted' style=' background-color:#6FB76F;  '></div>";
                break;

        }
        return html;

    };

    this.getOrderCustomerName = function (full) {

        var style = "";

        var name = full.InterpreterName;
        //if (full.Interpreter1 != null) {
        //    name = full.InterpreterName;
        //}

        var title = "";
        if (full.Interpreter1) {

            if (full.Interpreter1.Telephone)
                title += "tel : " + full.Interpreter1.Telephone;

            if (full.Interpreter1.Mobile) {

                if (title.length > 0)
                    title += ", ";

                title += "Mobile : " + full.Interpreter1.Mobile;

            }

        }

        if (name == "") {
            style = "style='background:#FF0000'";
            name = "&nbsp;&nbsp;&nbsp;&nbsp;"
        }

        if (full.TolkningInfo == "1")
            style = "style='background:#00FF00'";

        if (full.SkalIkkeFaktureres == true)
            style = "style='background:#CFCFCF'";



        if (full.OrderTypeId == 4 || full.OrderTypeId == 5 || full.OrderTypeId == 8)
            style = "style='background:#FFA500'";


        return "<div class='tableCustomDiv' " + style + " title='" + title + "'  >" + name + "</div>";
    };

    this.getTolkColor = function (full) {

        var check = true;
        if (full.SkalIkkeFaktureres == true)
            check = true;

        var abc = full.Interpreter;
        if (name == "")
            abc = 'style="background:#FF0000"';
        else
            abc = full.Interpreter;
        if (check == true)
            abc = 'style="background:#CFCFCF"';

        return abc;
    };

    this.getComplainDato = function (full) {

        var style = "";

        if (full.CbProblemStill == true) {
            style = "style='background:#ff6666;'";
        }
        else if (full.IsPrevious) {
            style = "style='background:#000000; color:#FFFFFF;'";
        }
        else if (full.IsTomorrow) {
            style = "style='background:#FF0000;'";
        }
        else {

        }


        return "<div " + style + " ><nobr>" + full.OrderDateString + "</nobr></div>";

    };

    this.getOrderLanguage = function (full) {

        //var languageName = "";

        //if (full.Language1 != null) {


        //    if (full.OrderType == 3) {
        //        languageName = full.Language1.Name + " - " + full.Language2.Name;
        //    }
        //    else
        //        languageName = full.Language1.Name;


        //}

        //return '<div>' + languageName + '</div>';

        return '<div>' + full.LanguageText + '</div>';

    };

    this.getOrderDateColorAndTitle = function (DateString) {

        var array = DateString.split("-");
        var d = new Date(array[2], array[1] - 1, array[0]);

        var currentDate = new Date(Date.now());
        var tomorrowDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 1);
        var color = '';

        if (d <= currentDate) {
            color = 'background:#000000; color:#FFFFFF;';
        }
        else if (+d == +tomorrowDate) {
            color = 'background:#FF0000';
        }
        else {
            color = "";
        }

        var daysOfWeek = new Array("Sunday", "Monday", "Tuesday", "Wednesday", "Thurday", "Friday", "Saturday");
        var day = daysOfWeek[d.getDay()];

        return '<div class="tableCustomDiv color-palette" style="'
                + color
                + '" title=' + day
                + '><nobr>' + DateString
                + '</nobr></div>';
    }


    this.getOrderDate = function (full) {

        var array = full.OrderDateString.split("-");
        var d = new Date(array[2], array[1] - 1, array[0]);

        var currentDate = new Date(Date.now());
        var tomorrowDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 1);
        var color = '';

        if (full.CbProblemStill) {
            color = 'background:#ff6666;';
        }
        else if (d <= currentDate) {
            color = 'background:#000000; color:#FFFFFF;';
        }
        else if (+d == +tomorrowDate) {
            color = 'background:#FF0000';
        }
        else {
            color = "";
        }

        return '<div style="' + color + '"><nobr>' + full.OrderDateString + '</nobr></div>';

    }


    this.getCustomerType = function (full) {


        var text = "";


        if (full.CustomerTypeId == "6") {
            text = "D";

        } else if (full.CustomerTypeId == "7") {

            text = "S";
        }

        return '<div>' + text + '</div>';

    }


    this.getInterpreterColorAndTitle = function (full) {
        var check = false;
        if (full.SkalIkkeFaktureres == true)
            check = true;
        var style = name;

        if (full.Interpreter == "")
            style = 'style = "background:#FF0000; height:50px"';
        else
            style = full.Interpreter;

        if (check == true)
            style = 'style = "background:#CFCFCF; height:50px"';

        var html = '<div ' + style + ' title="' + (full.Telephone == '' ? '' : full.Telephone + ' - ') + full.Mobile + '">' + full.Interpreter + '</div>';
        return html;
    }




















}