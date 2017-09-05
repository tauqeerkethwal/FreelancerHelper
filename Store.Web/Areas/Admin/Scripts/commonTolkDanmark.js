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



    this.getOrderColorCode = function (full) {
        //         debugger;
        var html = "";

        if (full.AflystIndenfo12 == "aee5225f-dbbe-439a-9d81-ff776c7fbe87" || full.AflystIndenfo12 == "5ff15c0f-e5f7-47c7-93db-19867c5a5518") {
            html += "<div title='Aflyst indenfor 12: Aflyst indenfor 24' style=' background-color:#FF1434;  '></div>";
        }

        if (full.Faktureret == true)
            html += "<div title='Faktureret: Faktureret' style=' background-color:#0A0401;  '></div>";

        if (full.IsKommune == true)
            html += "<div title='Kommune: Kommune' style=' background-color:#FF21E1;  '></div>";

        if (full.KundeBekraftelse == "b26c4cf0-c692-479a-947c-4c2c6fea91c3")
            html += "<div title='Kunde-bekræftelse: Bekræftet - mail' style=' background-color:#3EFF29;  '></div>";
        else if (full.KundeBekraftelse == "7e977664-d4e3-4f2b-84f2-15b0c172468a")
            html += "<div title='Kunde-bekræftelse: Bekræftet - tlf' style=' background-color:#3EFF29;  '></div>";
        else if (full.KundeBekraftelse == "a83aad8c-6274-4d5b-841b-66b38c4ddb85")
            html += "<div title='Kunde-bekræftelse: Bekræft - fax' style=' background-color:#3EFF29;  '></div>";


        if (full.IsLagerRegionSjalland == true)
            html += "<div title='Læger Region Sjælland: Læger Region Sjælland' style=' background-color:#FFFFFF;  '></div>";

        if (full.NavnOgEllerNrSend == true)
            html += "<div title='Skriftlig oversættelse: Ja' style=' background-color:#FFA621;  '></div>";

        if (full.RegSjAktiv == true)// "31955ab1-e32f-4687-951c-d97c1f3dffbe")
            html += "<div title='Reg sj Aktiv: Aktiv' style=' background-color:#FFB012;  '></div>";

        if (full.RegSjFaktureret == true)//"343181f5-ca1c-49f8-b1ec-a77218dfd655")
            html += "<div title='Reg sj faktureret: Ja' style=' background-color:#0DFFF7;  '></div>";
        else if (full.RegSjFaktureret == false)//"c71a9443-750e-4596-bd31-9c07beb680dc")
            html += "<div title='Reg sj faktureret: Aktiv' style=' background-color:#FF1C9D;  '></div>";

        if (full.IsRegion == true)
            html += "<div title='Region Sjælland: Region Sjælland' style=' background-color:#F8FF1F;  '></div>";

        if (full.SkalIkkeFaktureres == true)// "4dba641d-364f-4390-bcb7-5fe1d5e59216")
            html += "<div title='Skal ikke faktureres: Skal ikke faktureres' style=' background-color:#CFCFCF;  '></div>";

        if (full.TeleCatStatus == "4f34b791-5e45-46ce-b2da-803547c829be")
            html += "<div title='TELE: TELE' style=' background-color:#A3A03B;  '></div>";

        if (full.TolkBekraftelse == "1dfea48a-5bc5-457f-ad78-ece962793a4b")
            html += "<div title='Tolk-bekræftelse: Bekræftet - mail' style=' background-color:#2424FF;  '></div>";
        else if (full.TolkBekraftelse == "1f8e8e45-509d-41a4-8620-3b53b239efad")
            html += "<div title='Tolk-bekræftelse: Bekræft - sms' style=' background-color:#2424FF;  '></div>";

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