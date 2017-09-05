var commonManager = new function () {
    var _this = this;



    this.setUpDataTable = function (selector, url, columns, defaultOrder, fillExtraData, pageLength, onDraw) {
       

        if (!pageLength)
            pageLength = 100;
        var main_table_data = $(selector).DataTable({
            "dom": '<"top"lfip<"clear">>t<"bottom"ip<"clear">>',
            //"sDom":'lipft',
            "order": defaultOrder,
            "scrollY": 500,
            "scrollX": true,
            "processing": true, // for show progress bar
            "serverSide": true, // for process server side
            "filter": true, // this is for disable filter (search box)
            "bFilter": true,
            // "searchDelay": 1000,
            "orderMulti": false, // for disable multiple column at once
            // "lengthMenu": [[10, 25, 50, 100, 200, 300, 500, -1], [10, 25, 50, 100, 200, 300, 500, "All"]],
            "lengthMenu": [[10, 25, 50, 100, 200, 300, 400, 500, 800, 1000], [10, 25, 50, 100, 200, 300, 400, 500, 800, 1000]],
            "pageLength": pageLength,
            "ajax": {
               
                "url": url,
                "type": "POST",
                "datatype": "json",
                
                "data": function (d) {
                    if (fillExtraData) {
                        fillExtraData(d);
                    }


                }

            },
            "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                fnRowCallback(nRow, aData, iDisplayIndex, iDisplayIndexFull);
                
            },
            "initComplete": function (settings, json) {

                //   $(main_table_data).find(".dropdown-menu").last().addClass("last-table-action");

                //  $(selector + " tr:last .dropdown-menu").addClass("last-table-action");

            },
            "drawCallback": function (settings) {

                $(selector + " tr:last .dropdown-menu").addClass("last-table-action");

                if (onDraw) {
                    onDraw();

                }
            },
            "columns": columns
        });


        

        //.fnFilterOnReturn();
        //main_table_data.on('order.dt search.dt', function () {
        //            
        //              var d = fillExtraData
        //              main_table_data.column(0, { search: 'applied', order: 'applied', Page: 'applied' }).nodes().each(function (cell, i) {
        //                  cell.innerHTML = i + 1;
        //              });
        //          }).draw();
        $(selector + '_filter input').unbind();
        $(selector + '_filter input').bind('keyup', function (e) {


            var enterVal = this.value;

            if (e.keyCode == 13) {
                main_table_data.search(enterVal).draw();
            }
            else if (e.keyCode == 8 || e.keyCode == 46) {
                if (!enterVal || enterVal.length == 0) {
                    main_table_data.search("").draw();
                }
            }


        });

        return main_table_data;
    };


    this.setUpDataTableNoPaging = function (selector, url, columns, defaultOrder, fillExtraData) {


        var table = $(selector).DataTable({
            "dom": '<"top"i<"clear">>t<"bottom"i<"clear">>',
            "order": defaultOrder,
            "scrollY": 500,
            "scrollX": true,
            "pageLength": -1,
            "bPaginate": false,
            "bLengthChange": false,
            "processing": true, // for show progress bar
            "serverSide": true, // for process server side
            "filter": false, // this is for disable filter (search box)
            // "searchDelay": 1000,
            "orderMulti": false, // for disable multiple column at once
            "ajax": {
                "url": url,
                "type": "POST",
                "datatype": "json",
                "data": function (d) {
                    if (fillExtraData) {
                        fillExtraData(d);
                    }


                }

            },
            "columns": columns
        });



        return table;
    };


    this.showSuccessMessage = function (message) {

        if (!message) {
            message = "Saved Successfully.";
        }

        _this.showMessage(message, 'alert-success');

    };


    this.showErrorMessage = function (message) {

        if (!message) {
            message = "Error.";
        }

        _this.showMessage(message, 'alert-danger');

    };

    this.showMessage = function (message, bootstrapCss) {
        if (!message) {
            message = "No Message.";
        }

        var alertHtml = '<div class="alert ' + bootstrapCss + ' tolk-alert"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>';
        $(alertHtml).appendTo('body').delay(3000).fadeOut("slow", function () { $(alertHtml).remove() });
    };



    this.getSelectedCheckBoxesBySelector = function (className) {
        var names = [];
        $('.' + className + ':checked').each(function () {
            names.push($(this).val());
        });

        return names;
    };


    this.bindMultiSelectLanguage = function (selector, onLoad) {

        var LanguageURL = TOLK_DANMARK_BASE_URL + "/admin/home/GetAllLanguages";
        $.ajax({
            url: LanguageURL,
            success: function (result) {

                var list = result;
                $.each(list, function (index, language) {
                    $(selector).append($('<option>', {
                        value: language.Id,
                        text: language.Name
                    }));
                });

                $(selector).multiselect({
                    buttonWidth: '100%',
                    inheritClass: true,
                    maxHeight: 200,
                    enableFiltering: true,
                    enableCaseInsensitiveFiltering: true
                });

                if (onLoad)
                    onLoad();

            },
            error: function () {
                //alert("fail");
                commonManager.showErrorMessage("Unknown Error Occurred.");
            }
        });

    };


};



