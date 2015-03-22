
$("#ManufacturerID").attr("placeholder", "Начните вводить производителя");

$("#dialogDivModel").ready(function () {
    $('#ManufacturerID').autocomplete({
        source: '/Manufacturer/AutocompleteManufacturer'
    });


});

