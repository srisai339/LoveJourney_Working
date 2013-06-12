/* 
Jquery I2Space API Service
Developer: Satya
Copyright (C) 2012 
All Righs reserved

** functions outline **
    function fnSetFields()  
    function fnCheckString() 
    function fnRemoveSpecialChar(val) 
    function doUndoSelect(seatNo, seatAttribs)
    function add_seat(curseats, seatno)
    function remove_seat(curseats, seatno)
*/

/* ************************** */
/* function to initialize fields and set default properties */
/* *************************  */
function fnSetFields() {

    var myDate = new Date(serverDate);

    $('#txtDOJ').val($.datepicker.formatDate('dd-mm-yy', myDate));

    $('#txtDOJ').attr("readonly", "readonly");
    $('#txtDOR').attr("readonly", "readonly");
    
    $('#txtSource').keypress(function () { fnCheckString() });
    $('#txtDestination').keypress(function () { fnCheckString() });
    $('#txtDOJ').datepicker(
        {
            dateFormat: 'dd-mm-yy',
            firstDay: 0,
            buttonImageOnly: true,
            /*changeMonth: true,
            changeYear: true,*/
            numberOfMonths: 2,
            currentText: 'Now',
            showOn: 'focus',
            minDate: +0,
            maxDate: +100
        });
    $('#txtDOR').datepicker(
        {
            dateFormat: 'dd-mm-yy',
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
                var doj = new Date($('#txtDOJ').val().split('/')[1] + '/' + $('#txtDOJ').val().split('/')[0] + '/' + $('#txtDOJ').val().split('/')[2]);
                var dor = new Date(date.split('/')[1] + '/' + date.split('/')[0] + '/' + date.split('/')[2]);
                if (doj < dor) {
                    $('#txtDOR').val(date);
                    $(this).hide();
                }
                else {
                    alert('Onword journey date cannot be less than Return date');
                    $(this).show();
                }
            }
        });
}
  
    var validchars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /* ******************************* */
    /* Check and remove special characters from string */
    /* ****************************** */
    function fnCheckString() {
        //get the keycode when the user pressed any key in application 
        var exp = String.fromCharCode(window.event.keyCode)

        if (validchars.indexOf(exp) < 0 || validchars.indexOf(exp) > validchars.length) {
            window.event.keyCode = 0
            return false;
        }
    }

    function fnRemoveSpecialChar(val) {
        for (var i = 0; i < val.value.length; i++) {
            if (validchars.indexOf(val.value.charAt(i)) < 0 || validchars.indexOf(val.value.charAt(i)) > validchars.length) {
                val.value = val.value.replace(val.value.charAt(i), '');
            }
        }
    }

    /****************************************************/
    /* function to add or remove a seat to selected seats list */
    /****************************************************/
    function doUndoSelect(seatNo, seatAttribs) {

        var seatNoId = seatNo.replace(/[\s\(\)]/g, "");

        var attribArray = seatAttribs.split(","); //fare,type,status,isfemale

        var isSelected = 0;

        var isSelectedControl = ($('#hdnCurrentSeatSelection').val() == '') ? ('#isSelected' + seatNoId) : ('#isSelectedRet' + seatNoId);
        var seatsSelectedControl = ($('#hdnCurrentSeatSelection').val() == '') ? '#seatsSelected' : '#seatsSelectedRet';
        var seatsSelected1Control = ($('#hdnCurrentSeatSelection').val() == '') ? '#seatsSelected1' : '#seatsSelectedRet1';
        var fareTotalControl = ($('#hdnCurrentSeatSelection').val() == '') ? '#fareTotal' : '#fareTotalRet';
        var seatFareTotalControl = ($('#hdnCurrentSeatSelection').val() == '') ? '#seatFareTotal' : '#seatFareTotalRet';
        var seatCountControl = ($('#hdnCurrentSeatSelection').val() == '') ? '#seatCount' : '#seatCountRet';
        var totalFareDetailsControl = ($('#hdnCurrentSeatSelection').val() == '') ? '#totalFareDetails' : '#totalFareDetailsRet';
        var seatListControl = ($('#hdnCurrentSeatSelection').val() == '') ? '#seatList' : '#seatListRet';
        var seat_details_infoControl = ($('#hdnCurrentSeatSelection').val() == '') ? '#seat_details_info' : '#seat_details_infoRet';

        if ($.trim($(isSelectedControl).val()) != '')
            isSelected = $(isSelectedControl).val();

        //document.getElementById("isSelected" + seatNoId).value;

        var currseats = $(seatsSelectedControl).val();
        //var currseats = document.getElementById("seatsSelected").value;

        if (status != "booked") {

            var totalFare = 0;

            var totalFare = 0;
            if ($.trim($(fareTotalControl).html()) != '')
                totalFare = parseInt($(fareTotalControl).html());

            var seatTotalFare = 0;
            if ($.trim($(seatFareTotalControl).html()) != '')
                seatTotalFare = parseInt($(seatFareTotalControl).html());



            //var semiSlTotalFare = parseInt($('#semiSlTotalFare').html());
            //var sleeperTotalFare = parseInt($('#sleeperFareTotal').html());
            var currFare = parseInt(attribArray[0]);

            var seatCount = 0;
            if ($.trim($(seatCountControl).html()) != '')
                seatCount = parseInt($(seatCountControl).html());

            //var semiSlCount = parseInt($('#semiSlCount').html());
            //var sleeperCount = parseInt($('#sleeperCount').html());
            var available = "";
            var selected = "";
            //var ladies = "ladies3";


            if (attribArray[1].toLowerCase().indexOf('seat') != -1 || attribArray[1].toLowerCase().indexOf('semisleeper') != -1) {
                available = "available_seat";
                selected = "selected_seat";
                //ladies = "ladies";
            }
            if (attribArray[1].toLowerCase().indexOf('sleeper') != -1) {
                available = "available_" + attribArray[1].toLowerCase();
                selected = "selected_" + attribArray[1].toLowerCase();
                //ladies = "ladies";
            }

            if (isSelected == "0") {
                var currArray = currseats.split("|");

                if (currArray.length == 6) {
                    alert("You can select max 6 seats!");
                    return;
                }

                totalFare = totalFare + currFare;
                if (attribArray[1].toLowerCase().indexOf('seat') != -1) {
                    seatCount++;
                    seatTotalFare += currFare;
                }

                //Currently available is passed as parameter
                //if (status == "ladies")
                //    $('#seat' + seatNoId).removeClass(availableladies);
                //else
                //$('#seat' + seatNoId).removeClass(available);
                $('#li' + seatNoId).removeClass(available);

                //alert('#seat'+seatNo)
                //$('#seat' + seatNoId).addClass(selected);
                //Class shouls be added to li not <a> where is the seat
                $('#li' + seatNoId).addClass(selected);

                $(isSelectedControl).val("1");
                //document.getElementById("isSelected" + seatNoId).value = "1";
                currseats = add_seat(currseats, seatNo + "," + seatAttribs);
                $(seatsSelectedControl).val(currseats);
                //document.getElementById("seatsSelected").value = currseats;
            }
            else {
                totalFare = totalFare - currFare;
                if (attribArray[1].toLowerCase().indexOf('seat') != -1) {
                    seatCount--;
                    seatTotalFare -= currFare;
                }
                //else if (attribArray[1].indexOf('semisleeper') != -1) {
                //    semiSlCount--;
                //    semiSlTotalFare -= currFare;
                //}
                //else {
                //    sleeperCount--;
                //    sleeperTotalFare -= currFare;
                //}
                //$('#seat' + seatNoId).removeClass(selected);
                $('#li' + seatNoId).removeClass(selected);

                //if (status == "ladies")
                //    $('#seat' + seatNoId).addClass(availableladies);
                //else
                //$('#seat' + seatNoId).addClass(available);
                $('#li' + seatNoId).addClass(available);


                $(isSelectedControl).val("0");
                //document.getElementById("isSelected" + seatNoId).value = "0";
                currseats = remove_seat(currseats, seatNo + "," + seatAttribs);
                $(seatsSelectedControl).val(currseats);
                //document.getElementById("seatsSelected").value = currseats;
            }

            $(fareTotalControl).text(totalFare);
            $(totalFareDetailsControl).text(totalFare);
            $(seatCountControl).text(seatCount);
            //$('#semiSlCount').text(semiSlCount);
            //$('#sleeperCount').text(sleeperCount);
            $(seatFareTotalControl).text(seatTotalFare);
            //$('#sleeperFareTotal').text(sleeperTotalFare);
            //alert(document.getElementById("seatsSelected1").value);

            if (seatCount == 0)
                $(seat_details_infoControl).hide();
            else
                $(seat_details_infoControl).show();

            //if (semiSlCount == 0)
            //    $('#seamisl_details_info').hide();
            //else
            //    $('#seamisl_details_info').show();
            //if (sleeperCount == 0)
            //    $('#sleeper_details_info').hide();
            //else
            //    $('#sleeper_details_info').show();

            $(seatListControl).text($(seatsSelected1Control).val());
        }
    }

    /****************************************************/
    /* function to add seat to selected seats list */
    /****************************************************/
    function add_seat(curseats, seatno) {
        str = new String(curseats);

        var seatsSelected1Control = ($('#hdnCurrentSeatSelection').val() == '') ? '#seatsSelected1' : '#seatsSelectedRet1';

        if (str.length > 0) {
            var seatArr = seatno.split(",");
            var newCurSeatAfterPipeSplit = '';
            var newCurSeatAfterCommaSplit = '';
            var curSeatArr = curseats.split("|");
            for (var i = 0; i < curSeatArr.length; i++) {
                newCurSeatAfterPipeSplit = curSeatArr[i].split(",");
                if (newCurSeatAfterCommaSplit == "")
                    newCurSeatAfterCommaSplit = newCurSeatAfterPipeSplit[0];
                else
                    newCurSeatAfterCommaSplit = newCurSeatAfterCommaSplit + "," + newCurSeatAfterPipeSplit[0];
            }
            var bookSeat = newCurSeatAfterCommaSplit + "," + seatArr[0];

            $(seatsSelected1Control).val(bookSeat);

            //document.getElementById("seatsSelected1").value = bookSeat;
            if (seatArr[3] == 1) {
                alert("The seat you are trying to book (Seat No: " + seatArr[0] + ") is reserved for females. Male bookings are not allowed for this seat.");
            }
            return curseats + "|" + seatno;
        }
        else {
            var seatArr = seatno.split(",");
            var bookSeat = seatArr[0];
            $(seatsSelected1Control).val(bookSeat);

            //document.getElementById("seatsSelected1").value = bookSeat;
            if (seatArr[3] == 1) {
                alert("The seat you are trying to book (Seat No: " + seatArr[0] + ") is reserved for females. Male bookings are not allowed for this seat.");
            }
            return seatno;
        }
    }

    /****************************************************/
    /* function to remove seat from selected seats list */
    /****************************************************/
    function remove_seat(curseats, seatno) {

        var seatsSelected1Control = ($('#hdnCurrentSeatSelection').val() == '') ? '#seatsSelected1' : '#seatsSelectedRet1';

        str = new String(curseats);
        var toRem;
        var seatArr = curseats.split("|");
        for (i = 0; i < seatArr.length; i++) {
            var ind = seatArr[i];
            if (ind == seatno) {
                seatArr.splice(i, 1);
            }
        }
        var leftSeats = "";
        var leftSeatsWithFare = '';
        for (i = 0; i < seatArr.length; i++) {
            var ind = seatArr[i].split(',');
            //leftSeats = leftSeats + "," + ind[0];
            if (leftSeats == "") {
                leftSeats = ind[0];
            }
            else {
                leftSeats = leftSeats + "," + ind[0];
            }
            if (leftSeatsWithFare == "") {
                leftSeatsWithFare = ind;
            }
            else {
                leftSeatsWithFare = leftSeatsWithFare + "|" + ind;
            }
        }

        $(seatsSelected1Control).val(leftSeats);

        return leftSeatsWithFare;
    }

    $(document).mouseup(function (e) {
        //    var container = $("#divTravelsFilter");
        //    var containerDOJ = $("#divDOJ");
        //    var containerDOR = $("#divDOR");
        //    var container1 = $("#ul");

        $('[id^=tblCancellationPolicy]').hide();
        $('[id^=divDO]').hide();
        $('[id^=overlay]').hide();

        $('[id^=divBustype]').hide();
        $('[id^=divTravelsFilter]').hide();

        //    if (container.has(e.target).length == 0) {
        //        container.hide();
        //    }

    });
