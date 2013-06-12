/* 
Jquery EAN Hotels API Validations
Developer: Satya
Copyright (C) 2012 
All Righs reserved

** functions outline**

function fnSearchHotels()
function fnCheckString()
function fnBuildRoomsString(roomNo)
function fnSetDatePickers()
function function fnUpdateRooms()
function function fnUpdateChildCount(roomNo)
*/


var validchars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

/* ******************************* */
/* Check and remove special characters from string */
/* ****************************** */
function fnCheckString() {
    try {
        //get the keycode when the user pressed any key in application 
        var exp = String.fromCharCode(window.event.keyCode)

        if (validchars.indexOf(exp) < 0 || validchars.indexOf(exp) > validchars.length) {
            window.event.keyCode = 0
            return false;
        }
    }
    catch (err) {
        //txt = "There was an error on this page.\n\n";
        //txt += "Error description: " + err.message + "\n\n";
        //txt += "Click OK to continue.\n\n";
        //alert(txt);
        return false;
    }
    finally {
        //do something
    }
}

/* ************************* */
/* function to search hotels */
/* ************************* */
function fnSearchHotels() {
    try {
        if ($('#txtDestination').val() != '' &&
                 $('#txtDOA').val() != '' && $('#txtDOD').val() != '') {

            var rooms = '';
            for (var i = 1; i <= parseInt($('#ddlRoomCount').find(':selected').val()); i++) {
                if ($.trim(rooms) != '')
                    rooms += '~';
                rooms += fnBuildRoomsString(i);
            }

            window.name = "cityName=" + $('#txtDestination').val() +
                                                        "&arrivalDate=" + $('#txtDOA').val() +
                                                        "&departureDate=" + $('#txtDOD').val() +
                                                        "&roomDetails=" + rooms;
            //window.location.href = "SearchHotels.aspx";
            $('#lblDestination').html($('#txtDestination').val());
            $('#lblDOA').html($('#txtDOA').val());
            $('#lblDOD').html($('#txtDOD').val());
            $('#lblRoomCount').html($('#ddlRoomCount').find(':selected').val());

            fnGetAvailableHotels('{ "cityName":"' + $('#txtDestination').val() +
                                '", "arrivalDate":"' + $('#txtDOA').val() +
                                '", "departureDate":"' + $('#txtDOD').val() +
                                '", "roomDetails":"' + rooms + '"}');

            window.name = "cityName=" + $('#txtDestination').val() +
                                                        "&arrivalDate=" + $('#txtDOA').val() +
                                                        "&departureDate=" + $('#txtDOD').val() +
                                                        "&roomDetails=" + rooms;
            $('#hdnSearchParams').val(window.name);
            //$('#tblModifySearch').slideToggle();
            fnModifySearch();
        }
        else {
            alert('Please select destination, checkin checkout dates.');
        }
        return false;
    }
    catch (err) {
        var errorMessage = err.message;
    }
}

/* ************************************************ */
/* function to build rooms string (input parameter) */
/* ************************************************ */
function fnBuildRoomsString(roomNo) {
    var resultBuilder = '';

    try {
        //&room1=2,3,5    (2 Adults, 2 Children Ages 3 & 5)
        //&room2=2,10  (2 Adults, 2 Children Ages 10)
        resultBuilder += 'room' + roomNo + '=' +
                            $('#ddlRoom' + roomNo + 'AdultsCount').find(':selected').val();

        //check if at least one child is selected
        if (parseInt($('#ddlRoom' + roomNo + 'ChildCount').find(':selected').val()) > 0) {

            for (var i = 1; i <= parseInt($('#ddlRoom' + roomNo + 'ChildCount').find(':selected').val()); i++) {
                resultBuilder += ',' + $('#ddlRoom' + roomNo + 'Child' + i).find(':selected').val();
            }
        }
    }
    catch (err) {
        var errorMessage = err.message;
    }
    return resultBuilder;
}

/* ******************************************* */
/* function to set datepickers to input fields */
/* ******************************************  */
function fnSetDatePickers() {
    try {

        $('#txtDOA').attr("readonly", "readonly");
        $('#txtDOD').attr("readonly", "readonly");
        $('#txtDestination').keypress(function () { fnCheckString() });


        $('#divDOA').datepicker(
        {
            dateFormat: 'dd/mm/yy',
            firstDay: 0,
            buttonImageOnly: true,
            /*changeMonth: true,
            changeYear: true,*/
            numberOfMonths: 2,
            currentText: 'Now',
            showOn: 'focus',
            minDate: +0,
            maxDate: +100,
            onSelect: function (date) {
                $('#txtDOA').val(date);
                $(this).hide();
                $('#divDOD').show();
            }
        }).hide();


        $('#divDOD').datepicker(
        {
            dateFormat: 'dd/mm/yy',
            firstDay: 0,
            buttonImageOnly: true,
            /*changeMonth: true,
            changeYear: true,*/
            numberOfMonths: 2,
            currentText: 'Now',
            showOn: 'focus',
            minDate: +0,
            maxDate: +100,
            onSelect: function (date) {
                var doa = new Date($('#txtDOA').val().split('/')[1] + '/' + $('#txtDOA').val().split('/')[0] + '/' + $('#txtDOA').val().split('/')[2]);
                var dod = new Date(date.split('/')[1] + '/' + date.split('/')[0] + '/' + date.split('/')[2]);                
                if (doa < dod) {
                    $('#txtDOD').val(date);
                    $(this).hide();
                    $('#lnkSearchHotels').focus();
                }
                else {
                    alert('Checkin date cannot be less than Checkout date');
                    $(this).show();
                }
            }
        }).hide();

    }
    catch (err) {
        var errorMessage = err.message;
    }
}

/* **************************************************************** */
/* function to dynamically show rooms' dropdowns based on selected rooms count */
/* ***************************************************************  */
function fnUpdateRooms() {
    try {

        var roomCount = $('#ddlRoomCount').find(':selected').text();

        $('#trRoom1').hide();
        $('#trRoom2').hide();
        $('#trRoom3').hide();
        $('#trRoom4').hide();

        if (roomCount >= 1) $('#trRoom1').show();
        if (roomCount >= 2) $('#trRoom2').show();
        if (roomCount >= 3) $('#trRoom3').show();
        if (roomCount == 4) $('#trRoom4').show();
    }
    catch (err) {
        var errorMessage = err.message;
    }
}

/* ******************************************************************************* */
/* function to dynamically update children dropdowns based on selected child count */
/* ******************************************************************************* */
function fnUpdateChildCount(roomNo) {
    try {

        var childCount = $('#ddlRoom' + roomNo + 'ChildCount').find(':selected').val();

        $('#tdHeaderChild1').show();
        $('#tdHeaderChild2').show();
        $('#tdHeaderChild3').show();
        
        switch (parseInt(childCount)) {
            case 0:
                $('#tdRoom' + roomNo + 'Child1').hide();
                $('#tdRoom' + roomNo + 'Child2').hide();
                $('#tdRoom' + roomNo + 'Child3').hide();
                $('#tdHeaderChild1').hide();
                $('#tdHeaderChild2').hide();
                $('#tdHeaderChild3').hide();
                break;
            case 1:
                $('#tdRoom' + roomNo + 'Child1').show();
                $('#tdRoom' + roomNo + 'Child2').hide();
                $('#tdRoom' + roomNo + 'Child3').hide();
                $('#tdHeaderChild2').hide();
                $('#tdHeaderChild3').hide();
                break;
            case 2:
                $('#tdRoom' + roomNo + 'Child1').show();
                $('#tdRoom' + roomNo + 'Child2').show();
                $('#tdRoom' + roomNo + 'Child3').hide();
                $('#tdHeaderChild3').hide();
                break;
            case 3:
                $('#tdRoom' + roomNo + 'Child1').show();
                $('#tdRoom' + roomNo + 'Child2').show();
                $('#tdRoom' + roomNo + 'Child3').show();
                break;
        }
    }
    catch (err) {
        var errorMessage = err.message;
    }
}

$(document).mouseup(function (e) {

    $('[id^=divDO]').hide();
    $('[id^=overlay]').hide();

});