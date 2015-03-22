
var myTag = new Array();
var myPaperType = new Array();
var mySizePaper = new Array();

function GetParametrs($) {

     //   $('#ChosenTagIds input:checked').each(function () {
    //        myTag.push($(this).val());
    //    });
    $('#divTag input:checked').each(function () {
        myTag.push($(this).val());
    });

    $('#divSizePaper input:checked').each(function () {
        mySizePaper.push($(this).val());
    });

    $('#divPaperType input:checked').each(function () {
        myPaperType.push($(this).val());
    });
}

function showAddModel() {
    $('#dialogDivModel').load('/Model/PartialCreateModel/').dialog({
                autoOpen: true,
                title: 'Добавить модель',
                modal: true,
                resizable: true,
                width: 'auto',
                height: 'auto',
                
                buttons: 
                    {
                        "Добавить": function () {
                            
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
                                'Manufacturer': $('#Manufacturer').text(),
                                'Name': $('#Name').val(),
                                'DeviceType': $('#DeviceTypeID').val(),
                                'PrintKind': $('#PrintKindID').val(),
                                'TagsID': myTag,
                                'PaperTypesID': myPaperType,
                                'SizePapersID': mySizePaper
                            });
                            //!!!!!!!!!!!
                            //добавить или взять производителя addManuf / control Device AddManufacturer!!!!
                            //починить addmodel ниже!!!!
                        $.ajax({
                            type: 'POST',
                            url: '/Model/AddModel',
                            data: dataObject,
                            contentType: 'application/json',
                            success: function() {
                                $(this).dialog("close");
                            },
                            error: function(msg) { alert('Не удалось добавить модель'); }
                        });

                    },
                    "Отмена": function() { $(this).dialog("close"); }
                }
            });
        }
