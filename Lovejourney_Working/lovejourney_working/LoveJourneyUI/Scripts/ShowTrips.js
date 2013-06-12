function LoadDestinations() {
    var ddl = $("#ddlSources option:selected").text() == '----------' ? '' : $("#ddlSources option:selected").val();
    var ddlValue = $("#ddlSources option:selected").val();
    if (ddlValue == "----------") { return false; }
    $.ajax(
                {
                    type: "POST",
                    url: "ShowTrips.aspx/GetDestinations",
                    data: "{sourceId: '" + ddl + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        $("#destinationsDiv").html(msg.d);
                    },
                    error: function (x, e) {
                    }
                }
            );
}

function LoadRoutes(evt, arg) {

    $("#div_routes_loading").show();
    $("#div_routes").html('');

    document.getElementById("div_routes_loading").innerHTML = "<center><span> <img src='images/loading_text1.gif' alt='Loading' />  </span></center>";

    $.ajax(
                {
                    type: "POST",
                    url: "ShowTrips.aspx/GetRoutes",
                    data: "{Sorting: '" + arg.split('~')[0] + "', Filter: '" + arg.split('~')[1] + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    cache: false,
                    success: function (msg) {
                        fnLoadRouteStructure(msg);

                        var value = $("#hdnValue").val();
                        if (value == 0) {
                            var minMaxFares = msg.d[msg.d.length - 1];
                            $('#hdnMinFare').val(minMaxFares.split("|")[0]);
                            $('#hdnMaxFare').val(minMaxFares.split("|")[1]);
                            fnSetSliders();
                            $("#hdnValue").val(1);
                        }

                        $("#ddlOperator").multiselect({ noneSelectedText: "All Operators", selectedList: 1, selectedText: "# of # Selected", multiple: false, height: 200 });
                    },
                    error: function (x, e) {
                    }
                }
            );

}

function LoadFilteredRoutes(evt, sort) {
    var ddl = $("#ddlOperator option:selected").text() == 'All Operators' ? '' : $("#ddlOperator option:selected").text();

    var sort1 = sort == '' ? '~' : sort + '~';
    var arg = $('#cbAC').is(':checked') + ',' + $('#cbNONAC').is(':checked') + ',' + $('#cbSleeper').is(':checked') + ','
     + $('#cbSemiSleeper').is(':checked') + ',' + ddl + ',' + $('#hdnMinFare').val() + ','
     + $('#hdnMaxFare').val() + ',' + '0' + ',' + '23';

    LoadRoutes(evt, sort1 + arg);

    return false;
}

function LoadSeatLayout(evt, arg) {
    $("#btnContinue").hide().animate({ margin: 0 }, 10).fadeOut();
    $('html, body').animate({ scrollTop: 0 }, 'fast');
    $("#layout").html('<img src="images/big-flower.gif" />');
    $("#seatsSelected1").val("");
    $("#seatsSelected").val("");
    $("#seatList").text("");
    $("#totalFareDetails").text("0");
    $("#seatCount").text("0");
    $("#seatFareTotal").text("0");
    $("#fareTotal").text("0");
    $("#TravelInfo").text("");
    $("#modalbackground").show();
    $("#SeatLayout").show();

    $.ajax(
                {
                    type: "POST",
                    url: "ShowTrips.aspx/GetSeatLayout",
                    data: "{args: '" + arg + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function (msg) {

                        $("#layout").html(msg.d[1]);
                        $("#layout").append(msg.d[0]);
                        $("#TravelInfo").append(msg.d[2]);

                        var returnVal = msg.d[3];

                        if (returnVal == "btnContinueReturn") {
                            $("#btnContinueReturn").show().animate({ margin: 0 }, 10).fadeIn();
                        }
                        else if (returnVal == "btnContinue") {
                            $("#btnContinue").show().animate({ margin: 0 }, 10).fadeIn();
                        }
                        $contentLoadTriggered = false;
                    },
                    error: function (x, e) {
                        $("#SeatLayoutJQ").hide();
                        //alert("Failed to seat layout.");
                    }
                }
            );
    return false;
}

function SetPosition(evt, divID) {
    evt = (evt) ? evt : ((window.event) ? window.event : "");
    if (evt) {
        var elem = (evt.target) ? evt.target : evt.srcElement;
        x = evt.clientX;
        y = evt.clientY;
        if (document.documentElement || document.documentElement.scrollTop) { getTop = document.body.scrollTop + document.documentElement.scrollTop; }
        if (getTop != ' ' || getTop != '') { y = y + parseInt(getTop, 10); }
        var divObj = document.getElementById(divID);

        if (divObj != null) {

            divObj.style.position = "absolute";
            divObj.style.zIndex = "3000";

            if (divID == 'address_info') {
                divObj.style.left = (x + 30) + "px";
                divObj.style.top = (y - 20) + "px";
            }
            if (divID == 'address_info') {
                divObj.style.left = (x + 30) + "px";
                divObj.style.top = (y - 20) + "px";
            }
            if (divID == 'boardingpoint_info') {
                divObj.style.left = (x + 30) + "px";
                divObj.style.top = (y - 20) + "px";
            }
            if (divID == 'details_info') {

                divObj.style.left = (x - 30) + "px";
                divObj.style.top = (y + 20) + "px";
            }
            if (divID == 'SeatLayout') {
            }

            divObj.style.display = "block";
        }
    }
}

function showPanel(evt, divID, seatAttribs) {
    var x = 0;
    var y = 0;
    var getTop = 0;
    var setPosLeft = 0;
    var setPosTop = 0;
    if (seatAttribs != null) {
        if (divID == 'seat_info') {
            var attribArray = seatAttribs.split(","); //name,fare,typr
            $('#seatNo_ttip').text(attribArray[0]);
            $('#seatFare_ttip').text(parseInt(attribArray[1]));
            $('#seatType_ttip').text(attribArray[2]);
        }
        if (divID == 'boardingpoint_info') {
            var attribArray = seatAttribs.split("~"); //name,fare,typr
            $('#bpContactNumber_ttip').text(attribArray[0]);
            $('#bpLandmark_ttip').text(attribArray[1]);
            $('#bpAddress_ttip').text(attribArray[2]);
        }
    }

    evt = (evt) ? evt : ((window.event) ? window.event : "");
    if (evt) {
        var elem = (evt.target) ? evt.target : evt.srcElement;
        x = evt.clientX;
        y = evt.clientY;
        if (document.documentElement || document.documentElement.scrollTop) { getTop = document.body.scrollTop + document.documentElement.scrollTop; }
        if (getTop != ' ' || getTop != '') { y = y + parseInt(getTop, 10); }
        var divObj = document.getElementById(divID);
        if (divObj != null) {
            divObj.style.position = "absolute";
            divObj.style.zIndex = "3000";
            if (divID == 'seat_info') {
                divObj.style.left = (x - 30) + "px";
                divObj.style.top = (y + 25) + "px";
            }
            if (divID == 'boardingpoint_info') {
                divObj.style.left = (x + 30) + "px";
                divObj.style.top = (y - 20) + "px";
            }
            if (divID == 'details_info') {
                divObj.style.left = (x - 30) + "px";
                divObj.style.top = (y + 20) + "px";
            }
            divObj.style.display = "block";
        }
    }
}

function closePanel(getID) {
    if (document.getElementById(getID) != null)
        document.getElementById(getID).style.display = "none";
}

function SetValues() {
    document.getElementById("hdnBoardingPointIdJQ").value = $('#boardingpoint').val();
    document.getElementById("hdnSeatListJQ").value = $('#seatList').html();
    document.getElementById("hdnFareJQ").value = $('#totalFareDetails').html();
    document.getElementById("hdnTravelInfoJQ").value = $('#TravelInfo').html();

    var a = document.getElementById("hdnBoardingPointIdJQ").value;
    var b = document.getElementById("hdnSeatListJQ").value;
    var c = document.getElementById("hdnFareJQ").value;
    var d = document.getElementById("hdnTravelInfoJQ").value;

    document.getElementById("hdnBoardingPointNameJQ").value = $('#lblBoardingPoint').html();
    $("[id$=hdnFareJQ]").val($('#totalFareDetails').html());

    if (b == "") {
        alert("Please select atleast one seat."); return false;
    }
    if (a == "") {
        alert("Please select the BoardingPoint."); return false;
    }
    if (b == "" || a == "") { return false; }
    else { return true; }
}

function doUndoSelect(seatNo, seatAttribs) {
    var seatNoId = seatNo.replace(/[\s\(\)]/g, "");
    var attribArray = seatAttribs.split(","); //fare,type,status,isfemale
    var isSelected = 0;

    if ($('#isSelected' + seatNoId).val().trim() != '')
        isSelected = $('#isSelected' + seatNoId).val();

    //document.getElementById("isSelected" + seatNoId).value;
    var currseats = $('#seatsSelected').val();
    //var currseats = document.getElementById("seatsSelected").value;

    if (status != "booked") {

        var totalFare = 0;
        if ($('#fareTotal').html().trim() != '')
            totalFare = parseInt($('#fareTotal').html());

        var seatTotalFare = 0;
        if ($('#seatFareTotal').html().trim() != '')
            seatTotalFare = parseInt($('#seatFareTotal').html());

        //var semiSlTotalFare = parseInt($('#semiSlTotalFare').html());
        //var sleeperTotalFare = parseInt($('#sleeperFareTotal').html());
        var currFare = parseInt(attribArray[0]);

        var seatCount = 0;
        if ($('#seatCount').html().trim() != '')
            seatCount = parseInt($('#seatCount').html());

        //var semiSlCount = parseInt($('#semiSlCount').html());
        //var sleeperCount = parseInt($('#sleeperCount').html());
        var available = "available3";
        var selected = "selected3";
        //var ladies = "ladies3";


        if (attribArray[1].toUpperCase().indexOf('SEAT') != -1 || attribArray[1].toUpperCase().indexOf('SEMISLEEPER') != -1) {
            available = "available_seat";
            selected = "selected_seat";
            //ladies = "ladies";
        }
        if (attribArray[1].toUpperCase().indexOf('SLEEPER') != -1) {
            available = "available_sleeper";
            selected = "selected_sleeper";
            //ladies = "ladies";
        }

        if (isSelected == "0") {
            var currArray = currseats.split("|");
            if (currArray.length == 6) {
                alert("You can select max 6 seats!");
                return;
            }
            totalFare = totalFare + currFare;
            if (attribArray[1].toUpperCase().indexOf('SEAT') != -1) {
                seatCount++;
                seatTotalFare += currFare;
            }
            //else if (attribArray[1].indexOf('semisleeper') != -1) {
            //    semiSlCount++;
            //    semiSlTotalFare += currFare;
            //}
            //else {
            //    sleeperCount++;
            //    sleeperTotalFare += currFare;
            //}
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

            $('#isSelected' + seatNoId).val("1");
            //document.getElementById("isSelected" + seatNoId).value = "1";
            currseats = add_seat(currseats, seatNo + "," + seatAttribs);
            $('#seatsSelected').val(currseats);
            //document.getElementById("seatsSelected").value = currseats;
        }
        else {
            totalFare = totalFare - currFare;
            if (attribArray[1].toUpperCase().indexOf('SEAT') != -1) {
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

            $('#isSelected' + seatNoId).val("0");
            //document.getElementById("isSelected" + seatNoId).value = "0";
            currseats = remove_seat(currseats, seatNo + "," + seatAttribs);
            $('#seatsSelected').val(currseats);
            //document.getElementById("seatsSelected").value = currseats;
        }
        $('#fareTotal').text(totalFare);
        $('#totalFareDetails').text(totalFare);
        $('#seatCount').text(seatCount);
        //$('#semiSlCount').text(semiSlCount);
        //$('#sleeperCount').text(sleeperCount);
        $('#seatFareTotal').text(seatTotalFare);
        //$('#sleeperFareTotal').text(sleeperTotalFare);
        //alert(document.getElementById("seatsSelected1").value);
        if (seatCount == 0)
            $('#seat_details_info').hide();
        else
            $('#seat_details_info').show();
        //if (semiSlCount == 0)
        //    $('#seamisl_details_info').hide();
        //else
        //    $('#seamisl_details_info').show();
        //if (sleeperCount == 0)
        //    $('#sleeper_details_info').hide();
        //else
        //    $('#sleeper_details_info').show();
        $('#seatList').text(document.getElementById("seatsSelected1").value);
    }
}

function add_seat(curseats, seatno) {
    str = new String(curseats);
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

        $("#seatsSelected1").val(bookSeat);
        //document.getElementById("seatsSelected1").value = bookSeat;
        if (seatArr[3] == 1) {
            alert("The seat you are trying to book (Seat No: " + seatArr[0] + ") is reserved for females. Male bookings are not allowed for this seat.");
        }
        return curseats + "|" + seatno;
    }
    else {
        var seatArr = seatno.split(",");
        var bookSeat = seatArr[0];
        $("#seatsSelected1").val(bookSeat);
        //document.getElementById("seatsSelected1").value = bookSeat;
        if (seatArr[3] == 1) {
            alert("The seat you are trying to book (Seat No: " + seatArr[0] + ") is reserved for females. Male bookings are not allowed for this seat.");
        }
        return seatno;
    }
}

function remove_seat(curseats, seatno) {
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
    document.getElementById("seatsSelected1").value = leftSeats;
    return leftSeatsWithFare;
}

function fnLoadRouteStructure(arg) {
    if (arg != null) {
        $("#div_routes").html('');

        $("#TravelsFilter_dropdown").html(arg.d[arg.d.length - 2]);


        for (var routeid = 0; routeid < (arg.d.length - 2); routeid++) {
            var attribArray = arg.d[routeid].split("~");

            var html = '';

            html += "<div class=\"travel_main\">";
            html += "    <div class=\"travel_main_sub\">";
            html += "        <div class=\"showhide_topmain\">";
            html += "            <div class=\"travel_name\">";
            html += "                <span>" + attribArray[2] + "</span><br />";
            //Append cancellation
            html += "                <span class=\"t_cancellation\"><a id='\"lnkCancellation_" + routeid + "' onclick=\"fnGetCancellation('" + attribArray[3] + "~" + attribArray[2] + "~" + routeid + "~" + "Cancel" + "', this);\" " + "  title='Click to view cancellation policy' href='#'>" + "Cancellation Policy" + "</a></span>";
            html += "            </div>";
            html += "            <div class=\"travea_sleep\">";
            html += "                <span>" + attribArray[3] + "</span>";
            html += "            </div>";
            html += "            <div class=\"travea_time\">";
            //Append Dep time
            html += "                <a id='\"lnkDepTime_" + routeid + "' class='runtext' style='font-size:11px; font-family:Arial; font-weight: bold;color: #003b72;' onmouseover=\"fnGetPoints('" + attribArray[0] + "~" + attribArray[14] + "~" + routeid + "~" + "Boarding" + "~" + attribArray[12] + "', this);\" href='#'>" + attribArray[4] + "</a>";
            html += "                <div id=\"showpoints_" + routeid + "\" style=\"display: none; font-family:Verdana; font-size:smaller; position: absolute; padding: 10px; background-color: #FFEBCD; border: 1px Solid #FF8C00;\" onmouseout=\"$('#showpoints_" + routeid + "').hide();\"></div>";
            html += "            </div>";
            //Append arrivaltime
            html += "            <div class=\"travea_time\">";
            html += "                <a id='\"lnkArrTime_" + routeid + "' class='runtext' style='font-size:11px; font-family:Arial; font-weight: bold;color: #003b72;' onmouseover=\"fnGetPoints('" + attribArray[0] + "~" + attribArray[14] + "~" + routeid + "~" + "Dropping" + "~" + attribArray[13] + "', this);\" href='#'>" + attribArray[5] + "</a>";
            html += "                <div id=\"showpoints_" + routeid + "\" style=\"display: none;font-family:Verdana; font-size:smaller; position: absolute; padding: 10px; background-color: #FFEBCD; border: 1px Solid #FF8C00;\" onmouseout=\"$('#showpoints_" + routeid + "').hide();\"></div>";
            html += "            </div>";
            //Append travel time
            html += "            <div class=\"travea_duration\">";
            html += "                " + attribArray[6];
            html += "            </div>";

            //            html += "            <div class=\"t_avail\" style=\"vertical-align:bottom;\">";
            //            html += "                <img src='" + attribArray[16] + "' />";
            //            html += "            </div>";

            html += "            <div class=\"t_avail\">";
            html += "                Available " + attribArray[17];
            html += "            </div>";

            html += "            <div class=\"travel_price\">";
            html += "              Rs." + attribArray[7] + "/-";
            html += "            </div>";
            html += "        </div>";


            html += "        <div>";

            //Append hidden fields
            var hdnfields = '';
            hdnfields += "<input id=\"hdnAPI" + routeid + "\" type=\"hidden\" value=\"" + attribArray[0] + "\" />";
            hdnfields += "<input id=\"hdnlblS" + routeid + "\" type=\"hidden\" value=\"" + attribArray[14] + "\" />";
            hdnfields += "<input id=\"hdnTravelsJQ" + routeid + "\" type=\"hidden\" value=\"" + attribArray[2] + "\" />";
            hdnfields += "<input id=\"hdnBusTypeJQ" + routeid + "\" type=\"hidden\" value=\"" + attribArray[3] + "\" />";
            hdnfields += "<input id=\"hdnlblBJQ" + routeid + "\" type=\"hidden\" value=\"" + attribArray[15] + "\" />";
            hdnfields += "<input id=\"hdnServiceNumberJQ" + routeid + "\" type=\"hidden\" value=\"" + attribArray[11] + "\" />";
            hdnfields += "<input id=\"hdnBoardingPointsJQ" + routeid + "\" type=\"hidden\" value=\"" + attribArray[12] + "\" />";
            hdnfields += "<input id=\"hdnJourneyTypeJQ" + routeid + "\" type=\"hidden\" value=\"" + "Onward" + "\" />";
            //Append button

            //            if (attribArray[17] != "0") {
            hdnfields += "<button id=\"btnSelectSeats\" class='t_srch' onclick=\"return LoadSeatLayout(event, $('#hdnAPI" + routeid + "').val() + '~' +$('#hdnlblS" + routeid + "').val() + '~' + $('#hdnTravelsJQ" + routeid + "').val()+ '~' + $('#hdnBusTypeJQ" + routeid + "').val()+ '~' + $('#hdnlblBJQ" + routeid + "').val()+ '~' + $('#hdnServiceNumberJQ" + routeid + "').val()+ '~' + $('#hdnBoardingPointsJQ" + routeid + "').val() + '~' + $('#hdnJourneyTypeJQ" + routeid + "').val() );\">" + "View Seats" + "</button>";
            //            } else { hdnfields += "<button id=\"btnSelectSeats\" class='t_srch' onclick=\"return false;\">" + "Sold Out" + "</button>"; }

            html += hdnfields;

            html += "        </div>";
            html += "        <div style=\"clear: both;\">";
            html += "        </div>";
            html += "    </div>";
            html += "</div>";

            $("#div_routes").append(html);
        }
    }

    if ($("#div_routes").html() == "") {
        $("#BusesSorting").show();
        $("#div_routes").append("<center><h2>  Sorry! No Results Found For Journey  </h2></center>");
        if ($("#hdnValue").val() == 0) {
            $("#TravelsFilter_dropdown").html("<select id=\"ddlOperator\" name=\"ddlOperator\" class=\"Dropdownlist\"  > <option value=''>No Operators</option> </select>");
        }
    }
    else { $("#BusesSorting").show(); }

    $("#div_routes").show();
    $("#div_routes_loading").html('');
    $contentLoadTriggered = false;
}


function resetControls() {
    $('#cbAC').attr('checked', false);
    $('#cbNONAC').attr('checked', false);
    $('#cbSleeper').attr('checked', false);
    $('#cbSemiSleeper').attr('checked', false);

    if (document.getElementById('ddlOperator') != null) {
        document.getElementById('ddlOperator').selectedIndex = 0;
    }

    $("#minPriceLbl").text('1 Rs');
    $("#maxPriceLbl").text('2500 Rs');

    fnSetSliders();
}

function fnSetSliders() {

    var minA = ($("#hdnMinFare").val());
    var maxA = ($("#hdnMaxFare").val());

    $(function () {
        $("#slider-range").slider({
            range: true,
            min: parseInt(minA),
            max: parseInt(maxA),
            step: 50,
            disabled: false,
            orientation: 'horizontal',
            values: [parseInt(minA), parseInt(maxA)],
            slide: function (event, ui) {

                $('#hdnMinFare').val(ui.values[0]); $('#hdnMaxFare').val(ui.values[1]);
                $("#amount").val("" + ui.values[0] + "Rs  -  " + ui.values[1] + "Rs");

                LoadFilteredRoutes('', '');

            }
        });
        $("#amount").val("" + $("#slider-range").slider("values", 0) + "Rs  -  " + $("#slider-range").slider("values", 1) + "Rs");

        //        $("#slider-range").slider("option", "min", 1);
        //        $("#slider-range").slider("option", "max", 2500);
        //        $("#slider-range").slider('refresh');
    });
}

function ResetFilters() {

    $("#div_routes").html('');
    $("#div_routes_loading").show();
    $("#div_routes_loading").html('Loading...');
    $("#hdnValue").val(0);

    resetControls();
    LoadRoutes(this, 'none~none');
    return false;
}

function fnGetCancellation(arg) {
    var paramTravels = arg.split('~')[1];
    var paramindex = arg.split('~')[2];
    var paramType = arg.split('~')[0];
    $.ajax({
        type: "POST",
        url: "ShowTrips.aspx/GetCancellationPolicy",
        data: "{ travelsName: '" + paramTravels + "', busType: '" + paramType + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#Cancel1").html(msg.d);
            var popup = $("#Cancel1");
            document.getElementById('Cancel1').style.visibility = 'visible';
            $("#modalbackground").show();
            popup.show();
        }
    });
}

function CloseDiv() {
    document.getElementById('Cancel1').style.visibility = 'hidden';
    $("#modalbackground").hide();
}

function fnGetPoints(arg, element) {
    var paramdb = arg.split('~')[1];
    var paramapi = arg.split('~')[0];
    var paramindex = arg.split('~')[2];
    var paramPoint = arg.split('~')[3];
    var paramStringBP = arg.split('~')[4];

    var timer = setTimeout(function () {

        $('div[id^="showpoints_"]').hide();
        $.ajax({
            type: "POST",
            url: "ShowTrips.aspx/GetPoints",
            data: "{ BDParams: '" + paramdb + "', api: '" + paramapi + "', boardingOrDropping: '" + paramPoint + "', stringPoints: '" + paramStringBP + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $("#showpoints_" + paramindex).html(msg.d);
                $("#showpoints_" + paramindex).show();
                return false;
            },
            error: function (msg) {
            }
        });

    }, 150);

    element.onmouseout = function () {
        $("#showpoints_" + paramindex).hide();
        clearTimeout(timer);
    }
}

function fnGetPointsReturn(arg, element) {

    var paramdb = arg.split('~')[1];
    var paramapi = arg.split('~')[0];
    var paramindex = arg.split('~')[2];
    var paramPoint = arg.split('~')[3];
    var paramStringBP = arg.split('~')[4];

    var timer = setTimeout(function () {

        $('div[id^="showpointsReturn_"]').hide();
        $.ajax({
            type: "POST",
            url: "ShowTrips.aspx/GetPoints",
            data: "{ BDParams: '" + paramdb + "', api: '" + paramapi + "', boardingOrDropping: '" + paramPoint + "', stringPoints: '" + paramStringBP + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $("#showpointsReturn_" + paramindex).html(msg.d);
                $("#showpointsReturn_" + paramindex).show();
                return false;
            },
            error: function (msg) {
            }
        });

    }, 150);

    element.onmouseout = function () {
        $("#showpointsReturn_" + paramindex).hide();
        clearTimeout(timer);
    }
}

function VisiblePanel() {

    if ($("#btnModifySearch").val() == "Modify Search") {
        $("#btnModifySearch").val("Hide Search");
        $("#pnlModifyBox").show().animate({ margin: 0 }, 10).fadeIn();
        return false;
    }
    else if ($("#btnModifySearch").val() == "Hide Search") {
        $("#btnModifySearch").val("Modify Search");
        $("#pnlModifyBox").hide().animate({ margin: 0 }, 10).fadeOut();
        return false;
    }
}

function ValueChangedHandler(sender, args) {
    LoadFilteredRoutes('', '');
    $("#minPriceLbl").text($('#HiddenField1').val() + ' Rs');
    $("#maxPriceLbl").text($('#HiddenField2').val() + ' Rs');
}


function ValueChangedHandler1(sender, args) {
    LoadFilteredRoutes('', '');
    $("#minTimeLbl").text($('#HiddenField3').val());
    $("#maxTimeLbl").text($('#HiddenField4').val());
    SetTime();
}

function SetTime() {
    if ($('#HiddenField3').val() == "0") { $("#minTimeLbl").text("12:00 AM"); }
    else if ($('#HiddenField3').val() == "1") { $("#minTimeLbl").text("01:00 AM"); }
    else if ($('#HiddenField3').val() == "2") { $("#minTimeLbl").text("02:00 AM"); }
    else if ($('#HiddenField3').val() == "3") { $("#minTimeLbl").text("03:00 AM"); }
    else if ($('#HiddenField3').val() == "4") { $("#minTimeLbl").text("04:00 AM"); }
    else if ($('#HiddenField3').val() == "5") { $("#minTimeLbl").text("05:00 AM"); }
    else if ($('#HiddenField3').val() == "6") { $("#minTimeLbl").text("06:00 AM"); }
    else if ($('#HiddenField3').val() == "7") { $("#minTimeLbl").text("07:00 AM"); }
    else if ($('#HiddenField3').val() == "8") { $("#minTimeLbl").text("08:00 AM"); }
    else if ($('#HiddenField3').val() == "9") { $("#minTimeLbl").text("09:00 AM"); }
    else if ($('#HiddenField3').val() == "10") { $("#minTimeLbl").text("10:00 AM"); }
    else if ($('#HiddenField3').val() == "11") { $("#minTimeLbl").text("11:00 AM"); }
    else if ($('#HiddenField3').val() == "12") { $("#minTimeLbl").text("12:00 PM"); }
    else if ($('#HiddenField3').val() == "13") { $("#minTimeLbl").text("01:00 PM"); }
    else if ($('#HiddenField3').val() == "14") { $("#minTimeLbl").text("02:00 PM"); }
    else if ($('#HiddenField3').val() == "15") { $("#minTimeLbl").text("03:00 PM"); }
    else if ($('#HiddenField3').val() == "16") { $("#minTimeLbl").text("04:00 PM"); }
    else if ($('#HiddenField3').val() == "17") { $("#minTimeLbl").text("05:00 PM"); }
    else if ($('#HiddenField3').val() == "18") { $("#minTimeLbl").text("06:00 PM"); }
    else if ($('#HiddenField3').val() == "19") { $("#minTimeLbl").text("07:00 PM"); }
    else if ($('#HiddenField3').val() == "20") { $("#minTimeLbl").text("08:00 PM"); }
    else if ($('#HiddenField3').val() == "21") { $("#minTimeLbl").text("09:00 PM"); }
    else if ($('#HiddenField3').val() == "22") { $("#minTimeLbl").text("10:00 PM"); }
    else if ($('#HiddenField3').val() == "23") { $("#minTimeLbl").text("11:00 PM"); }

    if ($('#HiddenField4').val() == "23") { $("#maxTimeLbl").text("11:59 PM"); }
    else if ($('#HiddenField4').val() == "22") { $("#maxTimeLbl").text("10:59 PM"); }
    else if ($('#HiddenField4').val() == "21") { $("#maxTimeLbl").text("09:59 PM"); }
    else if ($('#HiddenField4').val() == "20") { $("#maxTimeLbl").text("08:59 PM"); }
    else if ($('#HiddenField4').val() == "19") { $("#maxTimeLbl").text("07:59 PM"); }
    else if ($('#HiddenField4').val() == "18") { $("#maxTimeLbl").text("06:59 PM"); }
    else if ($('#HiddenField4').val() == "17") { $("#maxTimeLbl").text("05:59 PM"); }
    else if ($('#HiddenField4').val() == "16") { $("#maxTimeLbl").text("04:59 PM"); }
    else if ($('#HiddenField4').val() == "15") { $("#maxTimeLbl").text("03:59 PM"); }
    else if ($('#HiddenField4').val() == "14") { $("#maxTimeLbl").text("02:59 PM"); }
    else if ($('#HiddenField4').val() == "13") { $("#maxTimeLbl").text("01:59 PM"); }
    else if ($('#HiddenField4').val() == "12") { $("#maxTimeLbl").text("12:59 PM"); }
    else if ($('#HiddenField4').val() == "11") { $("#maxTimeLbl").text("11:59 AM"); }
    else if ($('#HiddenField4').val() == "10") { $("#maxTimeLbl").text("10:59 AM"); }
    else if ($('#HiddenField4').val() == "9") { $("#maxTimeLbl").text("09:59 AM"); }
    else if ($('#HiddenField4').val() == "8") { $("#maxTimeLbl").text("08:59 AM"); }
    else if ($('#HiddenField4').val() == "7") { $("#maxTimeLbl").text("07:59 AM"); }
    else if ($('#HiddenField4').val() == "6") { $("#maxTimeLbl").text("06:59 AM"); }
    else if ($('#HiddenField4').val() == "5") { $("#maxTimeLbl").text("05:59 AM"); }
    else if ($('#HiddenField4').val() == "4") { $("#maxTimeLbl").text("04:59 AM"); }
    else if ($('#HiddenField4').val() == "3") { $("#maxTimeLbl").text("03:59 AM"); }
    else if ($('#HiddenField4').val() == "2") { $("#maxTimeLbl").text("02:59 AM"); }
    else if ($('#HiddenField4').val() == "1") { $("#maxTimeLbl").text("01:59 AM"); }
    else if ($('#HiddenField4').val() == "0") { $("#maxTimeLbl").text("12:59 AM"); }
}

$(document).mouseup(function (e) {
    var container = $("#ulBusFacilities");
    var container1 = $("#ul");

    if (container.has(e.target).length === 0) {
        container.hide();
    }
});