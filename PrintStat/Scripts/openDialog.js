
var myTag = new Array();
var myPaperType = new Array();
var mySizePaper = new Array();

function showAddModel() {
    $('#dialogDivModel').load('/Model/PartialCreateModel/').dialog({
                autoOpen: true,
                title: 'Добавить модель',
                modal: true,
                resizable: true,
                width: 'auto',
                height: 'auto',
                open: function (event, ui) {
                    var str = $('#Manufacturer').val();
                    //$('#ManufacturerID').val(str);
                    $('#ManufacturerID').attr("value",str);
                },
                buttons: 
                    {
                        "Добавить": function () {
                            var manufacturer = $('#ManufacturerID').val();
                            if (manufacturer == "") {
                                alert('Поле "Производитель" обязательно для заполнения');
                                return;
                            }
                            var manuf = { Name: manufacturer };
                            var idManuf;
                            $.post("/Manufacturer/AddManufacturer", manuf, null, "json")
                                .success(function(data) {
                                    myTag = [];
                                    myPaperType = [];
                                    mySizePaper = [];
                                    $('#divTag input:checked').each(function () {
                                        myTag.push($(this).val());
                                    });

                                    $('#divSizePaper input:checked').each(function () {
                                        mySizePaper.push($(this).val());
                                    });

                                    $('#divPaperType input:checked').each(function () {
                                        myPaperType.push($(this).val());
                                    });

                                    var dataObject = JSON.stringify({
                                        'ManufacturerID': data,
                                        'Name': $('#NameModel').val(),
                                        'DeviceTypeID': $('#DeviceTypeID').val(),
                                        'PrintKindID': $('#PrintKindID').val(),
                                        'ChosenTagIds': myTag,
                                        'ChosenPaperTypeIds': myPaperType,
                                        'ChosenSizePaperIds': mySizePaper
                                    });


                                    $.ajax({
                                        type: 'POST',
                                        url: '/Model/AddModel',
                                        data: dataObject,
                                        contentType: 'application/json',
                                        success: function (data) {
                                            if (!data) {
                                              //  $('#dialogDivModel').dialog("close");
                                                alert("Типо не добавил");
                                            }
                                        },
                                        error: function () { alert('Не удалось добавить модель'); }
                                    });

                                })
                                .error(function() {
                                alert("Не удалось добавить производителя");
                            });
                    },
                    "Отмена": function() {
                        $(this).dialog("close");
                    }
                }
            });
        }
