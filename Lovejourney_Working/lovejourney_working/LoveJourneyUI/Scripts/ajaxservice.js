/* 
Jquery I2Space API Service
Developer: Satya
Copyright (C) 2012 
All Righs reserved

** functions outline **
 
function fnInitializeAutoComplete() 
function fnLoadCities() 
function fnGetAvailableTrips(inputData, tripType, resultSet)
function GetMarkUpFare(actualPrice) 
function fnLoadTripslayout(data, tripType, isSingleTripData, resultSet)
function fnLoadSeatLayout(event, tripID, busType, travels, sourceId, destinationId, providerName) 
function fnFilterTrips(evt, sort) 
function fnSortTrips(event, sort, data) 
function fnLoadTravelsDropdown(data)    
function fnLoadBustypeDropdown() 
function BookSeats(tripID)
function fnShowPanel(evt, divID, seatAttribs)
function fnClosePanel(getID)
sort functions
function fnModifySearch() 
function fnIsReturnTrip()
function fnClearFilters()
function fnGoPrevDate() 
function fnGoNextDate()
function fnDateSearch(isNextDate, tripType)
function daysInMonth(month,year) 
function fnGetMonthName(arg)
function fnGetJourneyDuration(arg)
function fnBuildBoardingDroppingPoints(arg, argType, isSingleTripData, tripID) 
function fnLoadCancellationPolicy(arg)

*/

var AbhibusBoardingPointsControl = 'AbhibusBoardingPoints';
var hdnfilterdatacontrol = 'hdnfilterdata';
var b = true;
var searchFilterBarcontrol = 'searchFilterBar';
var modifySearchDetailsControl = 'modifySearchDetails';
var hdnAvailableTripsControl = 'hdnAvailableTrips';
var hdnAvailableTripssnfControl = 'hdnAvailableTripssnf';
var hdnAvailableReturnTripsControl = 'hdnAvailableReturnTrips';
var searchResultsControl = 'searchResults';
var searchDetailsDOJControl = 'searchDetailsDOJ';
//var divTravelsFilterControl = 'divTravelsFilter';
var divTravelsFilterControl = 'divFilterTravels';
var divBustypeControl = 'divBustype';
var cbACControl = 'cbAC';
var cbNONACControl = 'cbNONAC';
var cbSleeperControl = 'cbSleeper';
var cbSemiSleeperControl = 'cbSemiSleeper';
var cbSemiSleeperControl = 'cbSemiSleeper';
var ddlBoardingPointsControl = 'ddlBoardingPoints';
var selectedSeatsListControl = 'seatList';
var selectedSeatsFareControl = 'totalFareDetails';
var searchDetailsRouteControl = 'searchDetailsRoute';

//use these controls if search is done using dropdowns
//var ddlDestinationsControl = 'ddlDestinations';
//var ddlSourcesControl = 'ddlSources';
//use these controls if search is done using text boxes
/*********************************************************/
var hdnSourcesControl = 'hdnSources';
var hdnDestinationsControl = 'hdnDestinations';
var txtSourceControl = 'txtSource';
var txtDestinationControl = 'txtDestination';
var hdnSelectedSourceControl = 'hdnSelectedSource';
var hdnSelectedDestinationControl = 'hdnSelectedDestination';
/*********************************************************/
var txtDOJControl = 'txtDOJ';
var txtDORControl = 'txtDOR';
var hdnTripTypeControl = 'hdnTripType';
var hdnBookHotelControl = 'hdnBookHotel';


var rbRoundTripControl = 'rbRoundTrip';
var returnTripTextControl = 'returnTripText';
var hdnSelectedBoardingPointControl = 'hdnSelectedBoardingPoint';
var hdnSpecialPriceControl = 'hdnSpecialPrice';

//define sort function
jQuery.fn.sort = function () {
    return this.pushStack([].sort.apply(this, arguments), []);
}

/* ******************************************************************************** */
/* function to override autocomplete default(contains) search to starts with search */
/* ******************************************************************************** */
function fnInitializeAutoComplete() {
    $.ui.autocomplete.prototype._initSource = function () {
        var array, url;
        if ($.isArray(this.options.source)) {
            array = this.options.source;
            this.source = function (request, response) {
                // escape regex characters
                var matcher = new RegExp("^" + $.ui.autocomplete.escapeRegex(request.term), "i");
                response($.grep(array, function (value) {
                    return matcher.test(value.label || value.value || value);
                }));
            };
        } else if (typeof this.options.source === "string") {
            url = this.options.source;
            this.source = function (request, response) {
                $.getJSON(url, request, response);
            };
        } else {
            this.source = this.options.source;
        }
    };

    (function ($) {
        $(".ui-autocomplete-input").live("autocompleteopen", function () {
            var autocomplete = $(this).data("autocomplete"), menu = autocomplete.menu;
            if (!autocomplete.options.selectFirst) {
                return;
            }
            menu.activate($.Event({ type: "mouseenter" }), menu.element.children().first());
        });

    } (jQuery));
}


/* *********************************************************** */
/* function to load source and destination cities - text boxes */
/* *********************************************************** */
function fnLoadCities() {
    $.ajax({

        type: "POST",
        url: baseURL + "BusService.asmx/GetSources",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (result) {
            if (result.d != '') {
                //parse to json format
                var data = $.parseJSON(result.d);

                // data = $.parseJSON(data);
                //declare a variable to get city names 
                var cities = '[ ';

                //loop cities and add to dropdown
                $(data).each(function (index) {

                    if ($.trim(cities.toString()) != '[' && (cities.toString().lastIndexOf(',') + 1) != cities.length)
                        cities += ', ';

                    cities += '{ "label":"' + this.name + '","value":"' + this.id + '"}';
                });

                cities += ' ]';


                //set cities variable value to hidden field
                /** hdnSources is required only if text box is used for sources **/
                $('#hdnSources').val(cities);
                //comment this function to set autocomplete to default search
                fnInitializeAutoComplete();

                //set auto complete properties to text field
                $("#txtSource").autocomplete({
                    selectFirst: true,
                    source: $.parseJSON($('#hdnSources').val()),
                    minLength: 2,
                    maxItemsToShow: 20,
                    autoFocus: false,
                    select: function (event, ui) {
                        //prevent default action
                        event.preventDefault();
                        // set selected city id to hidden field
                        $('#hdnSelectedSource').val(ui.item.value);
                        //set selcted city name to text box
                        $(this).val(ui.item.label);
                        $("#txtDestination").val('');
                        $("#txtDestination").focus();

                    },
                    focus: function (event, ui) {
                        //prevent default action
                        event.preventDefault();
                        //set selcted city name to text box
                        //$(this).val(ui.item.label);
                    },
                    change: function (event, ui) {
                        //check if entered value is a valid city 
                        if (ui.item == null) {
                            $("#txtSource").val('Enter Source');
                            // alert('Please enter valid from city');
                            $('#hdnSelectedSource').val('');
                        }
                    }
                });

                //25-Nov-2012 : Show first item by default
                if ($("#txtSource").val() == '') {
                    //add cookies
                    if ($.cookie('SourceUser') != null && $.cookie('DestinationUser') != null) {
                        $("#txtSource").val($.cookie('SourceUser'));
                        $("#txtDestination").val($.cookie('DestinationUser'));
                        if ($.cookie('SelectedSourceUser') != null && $.cookie('SelectedDestinationUser') != null) {
                            $("#hdnSelectedSource").val($.cookie('SelectedSourceUser'));
                            $("#hdnSelectedDestination").val($.cookie('SelectedDestinationUser'));
                        }
                    }
                    else {
                        $("#txtSource").val('Enter Source');
                        //$('#hdnSelectedSource').val(data[1115].id);
                        $("#txtDestination").val('Enter Destination');
                        //$("#hdnSelectedDestination").val(data[303].id);

                    }

                }

                $("#txtSource").focus();

                //set cities variable value to hidden field
                /** hdnSources is required only if text box is used for sources **/
                $('#hdnDestinations').val(cities);

                $("#txtDestination").autocomplete({
                    selectFirst: true,
                    source: $.parseJSON($('#hdnDestinations').val()),
                    minLength: 2,
                    autoFocus: false,
                    select: function (event, ui) {
                        //pre vent default action
                        event.preventDefault();
                        // set selected city id to hidden field
                        $('#hdnSelectedDestination').val(ui.item.value);
                        //set selcted city name to text box
                        $(this).val(ui.item.label);
                        $('#divDOJ').show();
                    },
                    focus: function (event, ui) {
                        //prevent default action
                        event.preventDefault();
                        //set selcted city name to text box
                        //$(this).val(ui.item.label);
                    },
                    change: function (event, ui) {
                        //check if entered value is a valid city 
                        if (ui.item == null) {
                            $("#txtDestination").val('Enter Destination');
                            $('#hdnSelectedDestination').val('');
                        }
                    }
                });
            }
        },
        error: function (xhr, status, error) {
            //alert('Call to service failed.');
            //alert(xhr.responseText + " \n " + status + " \n " + error);
        }
    });
}
function fnLoadCitiesTours() {
    $.ajax({
        type: "POST",
        url: baseURL + "BusService.asmx/GetSourcesTours",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d != '') {
                //parse to json format
                var data = $.parseJSON(result.d);

                // data = $.parseJSON(data);
                //declare a variable to get city names 
                var cities = '[ ';

                //loop cities and add to dropdown
                $(data).each(function (index) {

                    if ($.trim(cities.toString()) != '[' && (cities.toString().lastIndexOf(',') + 1) != cities.length)
                        cities += ', ';

                    cities += '{ "label":"' + this.name + '","value":"' + this.id + '"}';
                });

                cities += ' ]';


                //set cities variable value to hidden field
                /** hdnSources is required only if text box is used for sources **/
                $('#hdnSources').val(cities);
                //comment this function to set autocomplete to default search
                fnInitializeAutoComplete();

                //set auto complete properties to text field
                $("#txtSource").autocomplete({
                    selectFirst: true,
                    source: $.parseJSON($('#hdnSources').val()),
                    minLength: 2,
                    maxItemsToShow: 20,
                    autoFocus: false,
                    select: function (event, ui) {
                        //prevent default action
                        event.preventDefault();
                        // set selected city id to hidden field
                        $('#hdnSelectedSource').val(ui.item.value);
                        //set selcted city name to text box
                        $(this).val(ui.item.label);
                        // $("#txtDestination").val('');
                        $("#txtDestination").focus();

                    },
                    focus: function (event, ui) {
                        //prevent default action
                        event.preventDefault();
                        //set selcted city name to text box
                        //$(this).val(ui.item.label);
                    },
                    change: function (event, ui) {
                        //check if entered value is a valid city 
                        if (ui.item == null) {
                            $("#txtSource").val('Enter Source');
                            // alert('Please enter valid from city');
                            $('#hdnSelectedSource').val('');
                        }
                    }
                });

                //25-Nov-2012 : Show first item by default
                //                if ($("#txtSource").val() == '') {
                //                    //add cookies
                //                    if ($.cookie('SourceUser') != null && $.cookie('DestinationUser') != null) {
                //                        $("#txtSource").val($.cookie('SourceUser'));
                //                        $("#txtDestination").val($.cookie('DestinationUser'));
                //                        if ($.cookie('SelectedSourceUser') != null && $.cookie('SelectedDestinationUser') != null) {
                //                            $("#hdnSelectedSource").val($.cookie('SelectedSourceUser'));
                //                            $("#hdnSelectedDestination").val($.cookie('SelectedDestinationUser'));
                //                        }
                //                    }
                //                    else {
                $("#txtSource").val(data[0].name);
                $('#hdnSelectedSource').val(data[0].id);
                $("#txtDestination").val(data[1].name);
                $("#hdnSelectedDestination").val(data[1].id);

                //                    }

                //                }

                $("#txtSource").focus();

                //set cities variable value to hidden field
                /** hdnSources is required only if text box is used for sources **/
                $('#hdnDestinations').val(cities);

                $("#txtDestination").autocomplete({
                    selectFirst: true,
                    source: $.parseJSON($('#hdnDestinations').val()),
                    minLength: 2,
                    autoFocus: false,
                    select: function (event, ui) {
                        //pre vent default action
                        event.preventDefault();
                        // set selected city id to hidden field
                        $('#hdnSelectedDestination').val(ui.item.value);
                        //set selcted city name to text box
                        $(this).val(ui.item.label);
                        $('#divDOJ').show();
                    },
                    focus: function (event, ui) {
                        //prevent default action
                        event.preventDefault();
                        //set selcted city name to text box
                        //$(this).val(ui.item.label);
                    },
                    change: function (event, ui) {
                        //check if entered value is a valid city 
                        if (ui.item == null) {
                            $("#txtDestination").val('Enter Destination');
                            $('#hdnSelectedDestination').val('');
                        }
                    }
                });
            }
        },
        error: function (xhr, status, error) {
            //alert('Call to service failed.');
            //alert(xhr.responseText + " \n " + status + " \n " + error);
        }
    });
}


/* ************************** */
/* function to load available trips */
/* *************************  */
function fnGetAvailableTrips(inputData, tripType, resultSet) {

    controltoLoad = $('#' + searchResultsControl);

    if (resultSet == 1)
        controltoLoad.html('<img src="' + baseURL + 'images/searching.gif" class="loading" />');
    if (b == true) {
        $('#' + divTravelsFilterControl).html('Loading Operators');
    }

    $.ajax({
        type: "POST",
        url: baseURL + "BusService.asmx/GetAvailableTrips",
        data: inputData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {

            if (resultSet == 1) {
                //hdnAvailableTripssnfControl
                $('#' + hdnAvailableTripsControl).val('');

                controltoLoad.html('');
            }

            //parse to json format
            var data = $.parseJSON(result.d);
            // data = $.parseJSON(data);
            // data = $(data.availableTrips).sort(SortByFares);
            if (data != null) {
                if (data.availableTrips != null) {
                    $('#' + hdnAvailableTripssnfControl).val('');
                    $('#' + hdnAvailableTripssnfControl).val(result.d);
                }
                var resultBuilder = '';
                if (data.responseStatus == "200" && data.availableTrips != '') {

                    var travels = '[';

                    //loop availableTrips and add to div
                    $(data.availableTrips).each(function (index) {

                        //build travels string       

                        if ($.trim(travels.toString()) != '[' && (travels.toString().lastIndexOf(',') + 1) != travels.length && travels.indexOf(this.travels) == -1)
                            travels += ',';
                        //check for duplicates
                        if (travels.indexOf(this.travels) == -1)
                        //travels += '"' + this.travels + '"';
                            travels += ' { "name" : "' + this.travels + '" }';
                    });

                    travels += ']';

                    //call function to bind data to travels dropdown
                    fnLoadFiltersDropdown(travels, divTravelsFilterControl);

                    //call function to bind data to travels dropdown
                    // fnLoadTravelsDropdown(travels);
                    //call function to load bus type dropdown
                    fnLoadBustypeDropdown();

                    //call GetMarkUpFare web method to get discount rates in % or amount
                    //this function is called asynchronously
                    //                    $.ajax({
                    //                        async: false,
                    //                        type: "POST",
                    //                        url: baseURL + "BusService.asmx/GetMarkUpFare",
                    //                        data: "",
                    //                        contentType: "application/json; charset=utf-8",
                    //                        dataType: "json",
                    //                        success: function (msg) {
                    //                            $('#' + hdnSpecialPriceControl).val(msg.d);
                    //                        }
                    //                    });
                    var availabletrips = $(data.availableTrips).sort(SortByFares);
                    $('#' + hdnAvailableTripsControl).val(availabletrips);
                    resultBuilder = fnLoadTripslayout(availabletrips, tripType, 'true', resultSet);

                    //Store search results in hidden field                
                    $('#' + hdnAvailableTripsControl).val(JSON.stringify($(data.availableTrips).sort(SortByFares), null, 2));
                    // $('#' + hdnAvailableTripsControl).val($('#' + hdnAvailableTripsControl).val() + data.availableTrips);
                }
                else {
                    if (resultSet == 1)
                    // resultBuilder = '<div style="text-align: center; padding: 10px; font-size: 20px;">' + data.availableTrips + '</div>';
                        resultBuilder = '<div style="text-align: center; padding: 10px; font-size: 20px;">Sorry no available trips found !!</div>';
                }

                /********* Return journey ************/
                if (tripType == 'return') {
                    if ($('#' + txtDORControl).val() != '') {
                        var tempReturnJourneyString = $.parseJSON(inputData);

                        var returnJourneyString = '{ "sourceId":"' + tempReturnJourneyString.destinationId +
                                    '", "destinationId":"' + tempReturnJourneyString.sourceId +
                                        '", "dateofjourney":"' + $('#' + txtDORControl).val() + '"}';

                        fnGetAvailableReturnTrips(returnJourneyString, resultBuilder);
                    }
                    else
                        alert('Please select return journey date');
                }
                else {
                    if (resultSet == 1)
                        controltoLoad.html(resultBuilder);
                    else
                        controltoLoad.append(resultBuilder);
                }
            }
            else {
                //controltoLoad.html('Sorry, No Available trips found');
            }
            //load next provider result set

            //if (b == true) {
            if (data != null) {

                if (parseInt(data.providersCount) > 0) {
                    b = false;
                    if (parseInt($('#hdnResultSetIndex').val()) > 0) {
                        $('#hdnResultSetIndex').val(parseInt($('#hdnResultSetIndex').val()) + 1);
                        var searchParams = $('#hdnSearchParams').val().split("&");
                        fnGetAvailableTrips('{ "sourceId":"' + searchParams[0].split('=')[1] +
                                                '", "destinationId":"' + searchParams[2].split('=')[1] +
                                                '", "dateofjourney":"' + searchParams[4].split('=')[1] +
                                                '", "resultSetIndex":"' + $('#hdnResultSetIndex').val() + '"}', 'single', $('#hdnResultSetIndex').val());

                    }
                }
                else {
                    b = true;
                }

            }
            else {
                $('#hdnResultSetIndex').val(parseInt($('#hdnResultSetIndex').val()) + 1);
            }
            //}
            //            else {
            //                b = true;
            //            }
        },
        error: function (xhr, status, error) {
            // controltoLoad.html('Sorry, No Available trips found');
            //alert('Call to service failed.');
            //alert(xhr.responseText + " \n " + status + " \n " + error);
        }
    });
}
/* ************************** */
/* function to load available return trips */
/* *************************  */
function fnGetAvailableReturnTrips(inputData, singleTripResult) {

    controltoLoad = $('#' + searchResultsControl);

    controltoLoad.html('<img src="' + baseURL + 'images1/searching.gif" class="loading" />');

    $.ajax({
        type: "POST",
        url: baseURL + "BusService.asmx/GetAvailableTrips",
        data: inputData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {

            var resultBuilderReturnTrip = '';

            //parse to json format
            var data = $.parseJSON(result.d);

            if (data != null) {
                resultBuilderReturnTrip = fnLoadTripslayout(data.availableTrips, 'false', 'false');

                //Store search results in hidden field
                var asdf = JSON.stringify(data.availableTrips, null, 2);
                var sdfd = $.parseJSON(data.availableTrips);
                $('#' + hdnAvailableReturnTripsControl).val(JSON.stringify(data.availableTrips, null, 2));
            }
            else
                resultBuilderReturnTrip = '<div style="text-align: center; padding: 10px; font-size: 20px;">Sorry, no available trips found !!</div>';


            controltoLoad.html('<table width="100%"><tr><td width="50%" valign="top" style="border-right: 2px dotted #DDEBF3;">' + singleTripResult + '</td><td width="50%" valign="top">' + resultBuilderReturnTrip + '</td></tr></table>');

        },
        error: function (xhr, status, error) {
            controltoLoad.html('');
            //alert('Call to service failed.');
            //alert(xhr.responseText + " \n " + status + " \n " + error);
        }
    });
}
/**********************************/
/* function to get modified price during festive seasons or weekends */
/**********************************/
function GetMarkUpFare(actualPrice) {
    //check if SpecialRates has value. If not return actual price
    if ($.trim($('#' + hdnSpecialPriceControl).val()) == '') {
        var price = actualPrice.split('/');
        var priceInt = '';
        for (var ii = 0; ii < price.length; ii++) {
            if (priceInt == '') {
                priceInt = parseInt(price[ii]);
            }
            else {
                priceInt = priceInt + "/" + parseInt(price[ii]);
            }


        }
        return priceInt;
    }
    else {
        var modifiedPrice = actualPrice;
        var specialPrice = $('#' + hdnSpecialPriceControl).val();

        //check if actualPrice contains multiple prices (ex: 900/950)
        if (actualPrice.indexOf('/') > -1) {
            modifiedPrice = '';
            var tempmodifiedPrice = 0;
            for (var k = 0; k < actualPrice.split('/').length; k++) {
                //check if specialPrice is in percentage
                if (specialPrice.indexOf('%') > -1) {
                    //check if specialPrice is in (-)ve percentage
                    if (specialPrice.indexOf('-') > -1) {
                        tempmodifiedPrice = parseInt(actualPrice.split('/')[k]) - ((actualPrice.split('/')[k] * parseInt(specialPrice.replace(/%/g, '').replace(/-/g, ''))) / 100);
                    }
                    else {
                        tempmodifiedPrice = parseInt(actualPrice.split('/')[k]) + ((actualPrice.split('/')[k] * parseInt(specialPrice.replace(/%/g, ''))) / 100);
                    }
                }
                //check if specialPrice is in rupees
                else {
                    //check if specialPrice is in (-)ve rupees
                    if (specialPrice.indexOf('-') > -1) {
                        tempmodifiedPrice = parseInt(actualPrice.split('/')[k]) - parseInt(specialPrice.replace(/-/g, ''));
                    }
                    else {
                        tempmodifiedPrice = parseInt(actualPrice.split('/')[k]) + parseInt(specialPrice);
                    }
                }

                if (modifiedPrice != '')
                    modifiedPrice += '/';
                modifiedPrice += tempmodifiedPrice;
            }
        }
        else {
            //check if specialPrice is in percentage
            if (specialPrice.indexOf('%') > -1) {
                //check if specialPrice is in (-)ve percentage
                if (specialPrice.indexOf('-') > -1) {
                    modifiedPrice = parseInt(actualPrice) - ((actualPrice * parseInt(specialPrice.replace(/%/g, '').replace(/-/g, ''))) / 100);
                }
                else {
                    modifiedPrice = parseInt(actualPrice) + ((actualPrice * parseInt(specialPrice.replace(/%/g, ''))) / 100);
                }
            }
            //check if specialPrice is in rupees
            else {
                //check if specialPrice is in (-)ve rupees
                if (specialPrice.indexOf('-') > -1) {
                    modifiedPrice = parseInt(actualPrice) - parseInt(specialPrice.replace(/-/g, ''));
                }
                else {
                    modifiedPrice = parseInt(actualPrice) + parseInt(specialPrice);
                }
            }
        }
        return modifiedPrice;
    }
}

/* ********************************* */
/* function to load build available trips result */
/* ********************************  */
var c = true;
var Agent = '';
var com = false;
function fnLoadTripslayout(data, tripType, isSingleTripData, resultSet) {

    //set table width based on trip type > single/return
    if (data != "") {
        var resultBuilder = (tripType == 'return') ?
        '<table cellspacing="0" cellpadding="0" style="width: 496px;"><tbody>' :
        '<table cellspacing="0" cellpadding="0" style="width: 1000px;"><tbody>';

        $.ajax({
            async: true,
            type: "POST",
            url: baseURL + "BusService.asmx/getagent",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                Agent = $.parseJSON(result.d);
                if (Agent != null) {
                    com = true;
                    // $("#snf").show();
                }
            },
            error: function (xhr, status, error) {
            }
        });

        //loop availableTrips and add to div
        $(data).each(function (index) {

            if (resultSet == "10") {
                $("#agentcom" + this.id).show();
            }
            else {
                $("#agentcom" + this.id).hide();
            }
            var selectedTravels = '';
            //check if atleast one travel is selected
            if ($('input[name=cblTravels]:checked').length > 0) {
                //loop through selected travels
                $('input[name=cblTravels]:checked').each(function (i, item) {
                    selectedTravels += ((i == 0) ? '' : ',') + $(item).attr('value');
                });

                selectedTravels = selectedTravels.split(',');
                var found = $.inArray(this.travels, selectedTravels) > -1;

                if (!found)
                //skip next lines of code and continue the loop
                    return true;
            }
            /***** boardingpoints filter ********/
            var selectedBoardingPoints = '';
            //check if atleast one boarding point is selected

            if ($('input[name=cblBoardingPointsFilter]:checked').length > 0) {
                //loop through selected boarding points
                $('input[name=cblBoardingPointsFilter]:checked').each(function (i, item) {
                    selectedBoardingPoints += ((i == 0) ? '' : ',') + $(item).attr('value');
                });

                selectedBoardingPoints = selectedBoardingPoints.split(',');

                var foundBP;
                //loop all boarding points to see if selectedBoardingPoints is there
                $(this.boardingTimes).each(function (i, item) {
                    //check if boarding point is present in array
                    foundBP = $.inArray(item.location, selectedBoardingPoints) > -1;
                    //skip the loop if boarding point is in array
                    if (foundBP)
                        return false;
                });

                if (!foundBP)
                //skip next lines of code and continue the loop
                    return true;
            }


            /***** dropping points filter ********/
            var selectedDroppingPoints = '';
            //check if atleast one dropping point is selected

            if ($('input[name=cblDroppingPointsFilter]:checked').length > 0) {
                //loop through selected dropping points
                $('input[name=cblDroppingPointsFilter]:checked').each(function (i, item) {
                    selectedDroppingPoints += ((i == 0) ? '' : ',') + $(item).attr('value');
                });

                selectedDroppingPoints = selectedDroppingPoints.split(',');

                var foundDP;
                //loop all boarding points to see if selectedBoardingPoints is there
                $(this.droppingTimes).each(function (i, item) {
                    //check if boarding point is present in array
                    foundDP = $.inArray(item.location, selectedDroppingPoints) > -1;
                    //skip the loop if boarding point is in array
                    if (foundDP)
                        return false;
                });

                if (!foundDP)
                //skip next lines of code and continue the loop
                    return true;
            }

            var busTypeFilter = '';

            busTypeFilter += $('#' + cbNONACControl).is(':checked') ? "Non A/C~" : "-------~";
            busTypeFilter += $('#' + cbNONACControl).is(':checked') ? "Non A/c~" : "-------~";
            busTypeFilter += $('#' + cbACControl).is(':checked') ? "A/C~" : "-------~";
            busTypeFilter += $('#' + cbSemiSleeperControl).is(':checked') ? "Semi Sleeper~SemiSleeper~" : "-------~";
            busTypeFilter += $('#' + cbSleeperControl).is(':checked') ? "Sleeper" : "-------";

            if (!$('#' + cbNONACControl).is(':checked') && !$('#' + cbACControl).is(':checked') &&
        !$('#' + cbSemiSleeperControl).is(':checked') && !$('#' + cbSleeperControl).is(':checked'))
                busTypeFilter = "~~~";

            if (this.busType.indexOf(busTypeFilter.split('~')[0]) > -1 || this.busType.indexOf(busTypeFilter.split('~')[1]) > -1 ||
            this.busType.indexOf(busTypeFilter.split('~')[2]) > -1 || this.busType.indexOf(busTypeFilter.split('~')[3]) > -1 ||
            this.busType.indexOf(busTypeFilter.split('~')[4]) > -1) {

                if ($('#' + cbACControl).is(':checked') && !$('#' + cbNONACControl).is(':checked'))
                    if (this.busType.indexOf('Non A/C') > -1)
                        return true;

                if ($('#' + cbSleeperControl).is(':checked') && !$('#' + cbSemiSleeperControl).is(':checked'))
                    if (this.busType.indexOf('SemiSleeper') > -1 || this.busType.indexOf('Semi Sleeper') > -1)
                        return true;

                var btnControl = (isSingleTripData.toString() == 'true') ? 'btnViewSeats' : 'btnViewSeatsRet';

                var markUpFare = GetMarkUpFare(this.fares == null ? 0 : this.fares.toString().replace(/,/g, '/'));


                var inputdt = '{ "actualPrice":"' + markUpFare + '"}';
                var Comm = '';

                $.ajax({
                    async: false,
                    type: "POST",
                    url: baseURL + "BusService.asmx/GetAgentSpecialPrice",
                    data: inputdt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        Comm = $.parseJSON(result.d);
                        if (Comm != null) {
                            if (c == true) {
                                c = false;
                                $("#snf").show();
                            }
                        }

                    },
                    error: function (xhr, status, error) {
                        //alert('agent');
                    }
                });



                resultBuilder += '<tr> ' +
                                '<td colspan="2"> <div id="' + this.id + '" >' +
                                    '<table width="100%" border="0" cellspacing="0" cellpadding="0" class="et_selectbus"> ' +
                                        '<tr>' +


                                            '<td width="80%" valign="top"> ' +
                                                '<table width="100%" border="0" cellspacing="0" cellpadding="0">' +
                                                    '<tr>' +
                                                        '<td class="et_tr_name" align="left" width="40%">' +
                                                            this.travels +
                                                        '</td>' +
                                                     '<td class="et_tr_seat pointer" align="left" width="17%">' +
            '<span id="id1"  onmouseover = "$(\'#dlBoardingPoints' + this.id + '\').show(\'fast\'); return false;" onmouseout="$(\'#dlBoardingPoints' + this.id + '\').hide(\'fast\'); return false;" >'
                                                           + this.departureTime +
                                                        '</span></td>' +
                                                        '<td class="et_tr_seat pointer" align="left" width="18%">' +
                //'<span id="id2" onmouseover = "$(\'#dlDroppingPoints' + this.id + '\').show(\'fast\'); return false;" onmouseout="$(\'#dlDroppingPoints' + this.id + '\').hide(\'fast\'); return false;"></span>' +
                                                            this.arrivalTime +
                                                        '</td>' +
                                                        '<td class="et_tr_seat" align="left" width="16%">' + this.duration +
                                                        '</td>' +
                                                        '<td class="et_tr_seat" align="left" width="17%"><span style="font-size: 11px;" id="availableSeats' + this.id +
                                                +'" name="availableSeats' + this.id + '"><strong>' +
                                                this.availableSeats + '</strong></span>'
                                                        + '</td>' +

                //                                                        
                                                    '</tr>' +
                                                    '<tr><td colspan="5">&nbsp;</td></tr>' +
                                                    '<tr>' +
                                                        '<td height="28" colspan="5" bgcolor="#95B3D7">' +
                                                            '<table width="100%" border="0" cellspacing="0" cellpadding="0">' +
                                                                '<tr> ' +
                //load cancellation policy
                                                                    '<td align="left" class="et_tr_seat" width="40%">' + this.busType + fnLoadCancellationPolicy(this.cancellationPolicy, this.partialCancellationAllowed, this.id) + ' </td> <td align="left" class="et_tr_seat">' +
                                                                        fnBuildBoardingDroppingPoints(this.boardingTimes, 'boarding', isSingleTripData, this.id) +
                                                                    '</td>' +
                                                                    '<td align="left" class="et_tr_seat">' +
                                                                        fnBuildBoardingDroppingPoints(this.droppingTimes, 'dropping', isSingleTripData, this.id) +
                                                                    '</td>' +
                                                                    '<td align="right" class="et_tr_seat pointer" height="25" onclick = "$(\'#tblCancellationPolicy' + this.id + '\').show(\'fast\'); $(\'#overlay\').show(); return false;" width="30%">' +
                //'Cancellation policy' +
                                                                    '</td>' +
                                                                    '<td width="10px" ></td>' +
                                                                '</tr>' +
                                                            '</table>' +
                                                        '</td>' +
                                                    '</tr>' +
                                                '</table>' +
                                            '</td>' +
                                        '</tr>' +
                                    '</table>' +
                                '</td>' +
                                '<td width="7"> </td>';
                // +
                if (parseInt(this.availableSeats) > 0) {
                    resultBuilder += '<td width="124" class="et_slct pointer" align="center" height="70" onclick="return fnLoadSeatLayout($(\'#' + btnControl + this.id + '\'), \'' +
                    //pass parameters to fnLoadSeatLayout function
                                                            this.id + '\', \'' + this.busType + '\', \'' + this.travels + '\', ' +
                                                            this.sourceId + ', ' + this.destinationId + ',' + markUpFare + ',' + this.SeatLayoutId + ', \'' + this.providerName + '\')">' +
                                                'Rs. <span class="pointer bold" >  ' + markUpFare + '/-</span> <br/>' +
                                                '<span id="agentcom' + this.id + '" class="pointer" style="display:none;color:#EC008C;" >Coms:' + Comm + ' <br/></span> ' +
                                                '<span id="' + btnControl + this.id + '" name="' + btnControl + this.id + '" title="Click here to view/book now." title1="show" >' +
                                                '<br/>Select Seats</span>' + //'<img alt="img" src="' + baseURL + 'images/down_arrow.png"/>'+
                                            '</td>';
                    // +

                }
                else {
                    resultBuilder += '<td width="124" class="et_slct" align="center" height="70">' +
                                                '<span style="color:Gray;font-weight:bold; font-size:medium;" >' +
                                                '<br/>Sold Out</span>' + //'<img alt="img" src="' + baseURL + 'images/down_arrow.png"/>'+
                                            '</td>';
                }
                resultBuilder += '</tr>' +
                            '<tr>' +
                                '<td height="10"> </td>' +
                            '</tr>';

                resultBuilder += '</tbody>';

                //check if single or return trip
                if (isSingleTripData.toString() == 'false') {
                    resultBuilder += '<tr><td align="center" colspan="2"> ' +
                                '<div class="dynamicSeatLayoutRet" id="dynamicSeatLayoutRet' + this.id + '"></div>';


                    resultBuilder += '</td></tr><tr><td class="gap" colspan="2"></td></tr>';
                }
                else {
                    resultBuilder += '<tr><td align="center"> ' +
                                '<div class="dynamicSeatLayout" id="dynamicSeatLayout' + this.id + '"></div>';
                    resultBuilder += '</td></tr><tr><td class="gap" colspan="2"></td></tr>';
                }
            }
        });

        resultBuilder += '</tbody></table></div>';

        return resultBuilder;
    }
}
function fnsnf() {

    $("#snf").hide();
    $("#dnf").show();

    var snfdata = $.parseJSON($('#' + hdnAvailableTripssnfControl).val());
    resultBuilder = fnLoadTripslayout(snfdata.availableTrips, "single", 'true', 10);

}
function fndnf() {
    $("#snf").show();
    $("#dnf").hide();
    var snfdata = $.parseJSON($('#' + hdnAvailableTripssnfControl).val());
    resultBuilder = fnLoadTripslayout(snfdata.availableTrips, "single", 'true', 1);
}
/* ************************** */
/* function to load available trips */
/* *************************  */
function fnLoadSeatLayout(event, tripID, busType, travels, sourceId, destinationId, markUpFare, SeatLayoutId, providerName) {


    var dynamicSeatLayoutId = ($(event).attr('id').indexOf('Ret') > 0) ? 'dynamicSeatLayoutRet' : 'dynamicSeatLayout';

    var btnViewSeatsId = ($(event).attr('id').indexOf('Ret') > 0) ? 'btnViewSeatsRet' : 'btnViewSeats';


    ($(event).attr('id').indexOf('Ret') > 0) ? $('#hdnSelectedBusOperatorRet').val(travels) : $('#hdnSelectedBusOperator').val(travels);
    ($(event).attr('id').indexOf('Ret') > 0) ? $('#hdnSelectedBusTypeRet').val(busType) : $('#hdnSelectedBusType').val(busType);

    if ($(event).attr('id').indexOf('Ret') > 0)
        $('#hdnReturnTripID').val(tripID);
    else
        $('#hdnSingleTripID').val(tripID);

    if (($(event).attr('id').indexOf('Ret') > 0)) {
        $('#hdnCurrentSeatSelection').val('return');
        $('#seatsSelectedRet').val('');
        $('#seatsSelectedRet1').val('');
        $('#totalFareDetailsRet').val('');
        $('#seatFareTotalRet').html('');
        $('#seatCountRet').html('');
        $('#fareTotalRet').html('');
        $('#hdnSelectedBoardingPointRet').val('');
    }
    else {
        $('#hdnCurrentSeatSelection').val('');
        $('#seatsSelected').val('');
        $('#seatsSelected1').val('');
        $('#totalFareDetails').val('');
        $('#seatFareTotal').html('');
        $('#seatCount').html('');
        $('#fareTotal').html('');
        $('#hdnSelectedBoardingPoint').val('');
    }

    //collapse all other seat layouts before loading the current one
    $('div[id^=dynamicSeatLayout]').slideUp();


    //set all buttons text to view seats
    //clear all matching div's html content.
    $('div[id^=dynamicSeatLayout]').each(function (i, item) {

        var divID = $(item).attr('id');
        if ((divID.indexOf('Ret') > 0)) {
            divID = divID.replace('dynamicSeatLayoutRet', '');
            if (divID != $('#hdnReturnTripID').val())
                $(item).html('');
        }
        else {
            divID = divID.replace('dynamicSeatLayout', '')
            if (divID != $('#hdnSingleTripID').val())
                $(item).html('');
        }
    });
    //$('div[id^=dynamicSeatLayout]').html('');

    //$('#hdnSingleTripID').val()

    //set all buttons text to view seats
    $('[id^=btnViewSeats]').html('<br/>Select Seats<br/>'); // + '<img alt="img" src="' + baseURL + 'images/down_arrow.png"/>'

    /*** These control is dynamically generated. Cannot be found in aspx page ***/
    if ($('#' + btnViewSeatsId + tripID).attr('title1') == 'show') {
        $('#' + btnViewSeatsId + tripID).attr('title1', 'hide');
        // $('#' + btnViewSeatsId + tripID).html('Loading<br/>'); // + '<img alt="img" src="' + baseURL + 'images/down_arrow.png"/>'
        $('#' + btnViewSeatsId + tripID).html('<img src="' + baseURL + 'images/123.gif" class="loading" />');
        $('#' + btnViewSeatsId + tripID).attr('disabled', true);
    }
    else {
        $('#' + btnViewSeatsId + tripID).attr('title1', 'show');
        $('#' + btnViewSeatsId + tripID).html('<br/>Select Seats<br/>'); // + '<img alt="img" src="' + baseURL + 'images/down_arrow.png"/>'
        $('#' + dynamicSeatLayoutId + tripID).slideUp();
        return;
    }

    controltoLoad = $('#' + dynamicSeatLayoutId + tripID);

    controltoLoad.html('<img src="' + baseURL + 'images/loading.gif" class="loading" />');

    $.ajax({
        type: "POST",
        url: baseURL + "BusService.asmx/GetTripDetails",
        data: "{tripId: '" + tripID + "', sourceId: '" + sourceId + "', destinationId: '" +
                destinationId + "' ,markUpFare:'" + markUpFare + "',  SeatLayoutId: '" + SeatLayoutId + "', journeyDate: '" + $('#' + txtDOJControl).val() + "' ,providerName: '" + providerName + "'}",

        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (result) {

            if (result != null && result.d != null) {
                controltoLoad.html('');

                result = $.parseJSON(result.d);
                if (result != null) {
                    //set provider name
                    $('#hdnSelectedProvider').val(result.providerName);
                    //close image to close seat layout
                    var layoutBuilder = '';

                    var boardingPoints = '';

                    //                if (($(event).attr('id').indexOf('Ret') > 0))
                    //                    fnBuildBoardingDroppingPoints(result.d[1], 'boarding', 'false', tripID);
                    //                else
                    //                    fnBuildBoardingDroppingPoints(result.d[1], 'boarding', 'true', tripID);
                    //                fnBuildBoardingDroppingPoints(this, 'dropping', isSingleTripData, tripID);
                    //hdnBoardingPoints

                    if ($(event).attr('id').indexOf('Ret') == -1) {
                        boardingPoints = '<select style=\"color: #000; font-size:12px; padding: 3px;\" id="ddlBoardingPoints' + tripID +
                                '" name="ddlBoardingPoints' + tripID + '" onchange="$(\'#' + hdnSelectedBoardingPointControl +
                                '\').val($(this).find(\':selected\').text()+\'~\'+$(this).find(\':selected\').val()); ';

                        boardingPoints += '" style="padding: 2px; border-radius: 3px; width: 150px;">';
                    }
                    else {
                        boardingPoints = '<select style=\"color: #000; font-size:12px; padding: 3px;\"  id="ddlBoardingPointsRet' + tripID +
                                    '" name="ddlBoardingPointsRet' + tripID + '" onchange="$(\'#' + hdnSelectedBoardingPointControl +
                                    'Ret\').val($(this).find(\':selected\').text()+\'~\'+$(this).find(\':selected\').val()); ';

                        boardingPoints += '" style="padding: 2px; border-radius: 3px; width: 150px;">';
                    }

                    boardingPoints += '<option value="0">-- Boarding Points --</option>';

                    //check if single or return trip

                    //                                if ($('#hdnBoardingPoints' + tripID).val() != null) {
                    //                                    boardingPointsData = $('#hdnBoardingPoints' + tripID).val();
                    //                                    //boardingPointsData = $('#hdnBoardingPoints' + tripID).val();

                    //                                }
                    var boardingPointsData;
                    if (result.boardingTimes != null) {
                        boardingPointsData = result.boardingTimes;
                    }
                    else {
                        $.ajax({
                            async: false,
                            type: "POST",
                            url: baseURL + "BusService.asmx/AvailResponse",
                            data: '',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (result) {
                                var Response = $.parseJSON(result.d);
                                //Response = null;
                                if (Response != null) {
                                    $(Response.availableTrips).each(function (i, item) {
                                        if (item.id == tripID) {
                                            boardingPointsData = this.boardingTimes;
                                            $(boardingPointsData).each(function (j, item) {
                                                // var loc = item.name.split('^^');
                                                boardingPoints += '<option value="' + item.pointId + '">' + item.name + ' - ' + item.time + ' - ' + item.address + '</option>';
                                                //                                                $('#' + AbhibusBoardingPointsControl).val('');
                                                //                                                $('#' + AbhibusBoardingPointsControl).val(item.address);
                                            });
                                        }
                                    }

                          );
                                }
                                else {
                                    var availabledata = $.parseJSON($('#' + hdnAvailableTripsControl).val());
                                    $(availabledata).each(function (i, item) {
                                        if (item.id == tripID) {
                                            boardingPointsData = this.boardingTimes;
                                            $(boardingPointsData).each(function (j, item) {
                                                // var loc = item.name.split('^^');
                                                boardingPoints += '<option value="' + item.pointId + '">' + item.name + ' - ' + item.time + ' - ' + item.address + '</option>';
                                            });
                                        }
                                    }

                          );

                                }


                            },
                            error: function (xhr, status, error) {
                                //alert('Call to service failed');
                                //alert(xhr.responseText + " \n " + status + " \n " + error);
                            }
                        });

                    }
                    //                else
                    //                    boardingPointsData = ($(event).attr('id').indexOf('Ret') == -1) ? $('#hdnBoardingPoints' + tripID).val() : $('#hdnBoardingPointsRet' + tripID).val();

                    if (result.boardingTimes != null) {
                        $(boardingPointsData).each(function (i, item) {
                            boardingPoints += '<option value="' + item.pointId + '">' + item.location + ' - ' + item.time + '</option>';
                        });
                    }


                    boardingPoints += '</select>';

                    if ($(event).attr('id').indexOf('Ret') == -1) {
                        layoutBuilder += '<table width="100%" cellspacing="0"> <tr> <td align="left" class="selectedseats_info">' +
                        // hidden fields to validate select seats
                            '<input id="seatsSelected1" type="hidden" value="" name="seatsSelected1" />' +
                            '<input id="seatsSelected" type="hidden" value="" name="seatsSelected" />' +
                        //show selected seats list
                            '<span>Selected Seat(s): <strong><span id="seatList"></span></strong></span>' +
                        //show total fare for seats selected
                            '<span>Total Fare:</span> <span> Rs. <strong><span id="totalFareDetails" class="redText"></span></strong></span>' +
                            '</td> <td align="left" valign="middle" class="selectedseats_info">' +
                            '<span class="underline pointer" onmouseout="fnClosePanel(\'details_info\');" onmouseover="fnShowPanel(event,\'details_info\',null);">Details</span>' +
                            '</td><td class="selectedseats_info" align="right">&nbsp;<img alt="img" style="width: 18px; height: 18px; margin:0; border: none; padding:0; position: absolute;" src="' + baseURL + 'images/closeseatlayout.png" class="pointer" onclick="$(\'#' + dynamicSeatLayoutId + tripID + '\').slideUp(); $(\'#' + btnViewSeatsId + tripID + '\').html(\'<br/>Select Seats\'); " />' +
                            '</td> </tr>';
                        //append seat layout
                    }
                    else {
                        layoutBuilder += '<table width="100%" cellspacing="0"> <tr> <td align="left" class="selectedseats_info">' +
                        // hidden fields to validate select seats
                            '<input id="seatsSelectedRet1" type="hidden" value="" name="seatsSelectedRet1" />' +
                            '<input id="seatsSelectedRet" type="hidden" value="" name="seatsSelectedRet" />' +
                        //show selected seats list
                            '<span>Selected Seat(s): <strong><span id="seatListRet"></span></strong></span>' +
                        //show total fare for seats selected
                            '<span>Total Fare:</span> <span> Rs. <strong><span id="totalFareDetailsRet" class="redText"></span></strong></span>' +
                            '</td> <td align="left" align="right" class="selectedseats_info" valign="middle">' +
                            '<span class="underline pointer" onmouseout="fnClosePanel(\'details_infoRet\');" onmouseover="fnShowPanel(event,\'details_infoRet\',null);">Details</span>' +
                            '&nbsp;<img alt="img" style="width: 18px; height: 18px; margin:0; border: none; position: absolute; padding:0;" src="' + baseURL + 'images/closeseatlayout.png" class="pointer" onclick="$(\'#' + dynamicSeatLayoutId + tripID + '\').slideUp(); $(\'#' + btnViewSeatsId + tripID + '\').html(\'<br/>Select Seats\'); " />' +
                            '</td> </tr>';
                        //append seat layout
                    }

                    //condition to check if triptype is return trip
                    if ($('#' + hdnTripTypeControl).val() == 'return') {

                        layoutBuilder += '<tr>  <td colspan="2" align="center"> ' + result.SeatsScript;

                        //continue button to book seats
                        layoutBuilder += '</td> </tr><tr><td colspan="2" height="10"></td></tr> <tr> <td align="center">';

                        layoutBuilder += boardingPoints +
                            '</td><td align="left">' +
                            '<span class="button bold" style="background-color: #D62F02;" id="btnContinue" name="btnContinue" onclick="return BookSeats(\'' + tripID + '\');" >Continue</span>' +
                            '</td> </tr> <tr><td colspan="2" height="10"></td></tr></table>';
                    }
                    else {
                        layoutBuilder += '<tr>  <td align="center"> ' + result.SeatsScript +
                                '</td> <td style="border-bottom: 0px;" valign="bottom"> <img src="' + baseURL + 'images/desc.png" /> <br /> <br />';

                        //continue button to book seats
                        layoutBuilder += '</td> </tr> <tr> <td align="center"> ' + boardingPoints + '</td><td colspan="2" align="left">' +
                            '<span class="button bold" style="background-color: #D62F02;" id="btnContinue" name="btnContinue" onclick="return BookSeats(\'' + tripID + '\',\'' + sourceId + '\',\'' + destinationId + '\');" >Continue</span>' +
                            '</td> </tr> </table>';
                    }

                    $('#' + btnViewSeatsId + tripID).html('<br/>Hide Seats<br/>'); //<img alt="img" src="' + baseURL + 'images/up_arrow.png"/>
                    $('#' + btnViewSeatsId + tripID).attr('disabled', false);
                    controltoLoad.html(layoutBuilder);
                    if ($('#' + btnViewSeatsId + tripID).attr('title1') == 'hide') {

                        fnShowHeaderonScroll123(tripID);
                    }
                    controltoLoad.slideDown();
                    controltoLoad.focus();
                }
                else {
                    alert('Service no longer running!');
                    $('#' + btnViewSeatsId + tripID).attr('title1', 'show');
                    $('#' + btnViewSeatsId + tripID).html('<br/>Select Seats<br/>'); // + '<img alt="img" src="' + baseURL + 'images/down_arrow.png"/>'
                    $('#' + dynamicSeatLayoutId + tripID).slideUp();
                    return;
                }
            }
        },
        error: function (xhr, status, error) {
            //alert('Call to service failed');
            //alert(xhr.responseText + " \n " + status + " \n " + error);
        }
    });
}

/* ************************ */
/* function to filter trips */
/* ************************ */
function fnFilterTrips(event, sort) {
    var data = '';

    $('#' + searchResultsControl).html('<img src="' + baseURL + 'images/searching.gif" class="loading" />');

    $.ajax({
        async: false,
        type: "POST",
        url: baseURL + "BusService.asmx/AvailResponse",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var Res = $.parseJSON(result.d);

            if (sort != null) {
                data = fnSortTrips(event, sort, Res.availableTrips);
                // returnTripdata = fnSortTrips(event, sort, returnTripdata);
                ($(event).attr('title1') == 'asc') ? $(event).attr('title1', 'desc') : $(event).attr('title1', 'asc');
            }
            else
                $('#' + searchResultsControl).html(fnLoadTripslayout(Res.availableTrips, $('#' + hdnTripTypeControl).val(), 'true'));

        },
        error: function (xhr, status, error) {
            //alert('Call to service failed');
            //alert(xhr.responseText + " \n " + status + " \n " + error);
        }
    });


    // var data = $.parseJSON(ss);
    // var returnTripdata = $.parseJSON($('#' + hdnAvailableReturnTripsControl).val());


    //Call fnLoadTrips layout to frame available trips data and set it to search results

    //check if is single or return trip and build html
    if ($('#' + hdnTripTypeControl).val().toString() == 'return')
        $('#' + searchResultsControl).html('<table width="100%"><tr><td width="50%" valign="top" style="border-right: 2px dotted #DDEBF3;">' + fnLoadTripslayout(data, $('#' + hdnTripTypeControl).val(), 'true', 0) + '</td><td width="50%" valign="top">' + fnLoadTripslayout(returnTripdata, $('#' + hdnTripTypeControl).val(), 'false', 0) + '</td></tr></table>');
    else
        $('#' + searchResultsControl).html(fnLoadTripslayout(data, $('#' + hdnTripTypeControl).val(), 'true', 0));
    //return false;
}

/* ************************ */
/* function to sort trips */
/* ************************ */
function fnSortTrips(event, sort, data) {

    switch (sort) {
        case "travels":
            data = ($(event).attr('title1') == 'asc') ? $(data).sort(SortByTravels) : $(data).sort(SortByTravelsDesc);
            break;
        case "bustype":
            data = ($(event).attr('title1') == 'asc') ? $(data).sort(SortByBusType) : $(data).sort(SortByBusTypeDesc);
            break;
        case "dep":
            data = ($(event).attr('title1') == 'asc') ? $(data).sort(SortByDepartureTime) : $(data).sort(SortByDepartureTimeDesc);
            break;
        case "arr":
            data = ($(event).attr('title1') == 'asc') ? $(data).sort(SortByArrivalTime) : $(data).sort(SortByArrivalTimeDesc);
            break;
        case "Dur":
            data = ($(event).attr('title1') == 'asc') ? $(data).sort(SortByDuration) : $(data).sort(SortByDurationDesc);
            break;
        case "seats":
            data = ($(event).attr('title1') == 'asc') ? $(data).sort(SortByAvailableSeats) : $(data).sort(SortByAvailableSeatsDesc);
            break;
        case "fare":
            data = ($(event).attr('title1') == 'asc') ? $(data).sort(SortByFares) : $(data).sort(SortByFaresDesc);
            break;
        case undefined:
        case null:
            data = ($(event).attr('title1') == 'asc') ? $(data).sort(SortByID) : $(data).sort(SortByIDDesc);
            break;
    }

    //return sorted data
    return data;
}

/* ********************************* */
/* function to load travels/boarding points/dropping points dropdown */
/* ********************************  */

function fnLoadFiltersDropdown(data, controltoLoad) {

    var cblControl;
    switch (controltoLoad) {
        case divTravelsFilterControl:
            cblControl = 'cblTravels';
            break;
        case divBoardingPointsFilterControl:
            cblControl = 'cblBoardingPointsFilter';
            break;
        case divDroppingPointsFilterControl:
            cblControl = 'cblDroppingPointsFilter';
            break;
    }

    var sortedList = $.parseJSON(data).sort(SortByName);
    if (b == true) {
        $('#' + controltoLoad).html('');
        $('#' + hdnfilterdatacontrol).html('');
        //$('#' + controltoLoad).html('<img alt="img" src="' + baseURL + 'images/closeseatlayout.png" width="16" class="floatRight pointer" onclick="$(\'#' + controltoLoad + '\').slideUp(); "/><br/>');
        //loop travels and add to dropdown
        $(sortedList).each(function (index) {
            $('#' + controltoLoad).append('<input type="checkbox" name="' + cblControl + '" value="' + this.name + '" title="' + this.name + '" />&nbsp;&nbsp;' + this.name + ' </br>');
        });
        $('#' + hdnfilterdatacontrol).val(data);
    }
    else {
        var sort = $.parseJSON($('#' + hdnfilterdatacontrol).val());
        $(sort).each(function (index) {
            $('#' + controltoLoad).append('<input type="checkbox" name="' + cblControl + '" value="' + this.name + '" title="' + this.name + '" />&nbsp;&nbsp;' + this.name + ' </br>');
        });
        $(sortedList).each(function (index) {
            $('#' + controltoLoad).append('<input type="checkbox" name="' + cblControl + '" value="' + this.name + '" title="' + this.name + '" />&nbsp;&nbsp;' + this.name + ' </br>');
        });
    }

    $('input[name=' + cblControl + ']').change(function () {

        fnFilterTrips(this, null);
        $(this).attr('checked', ($(this).attr('checked')));
        //return false;
    });
}

/* ********************************* */
/* function to load travels dropdown */
/* ********************************  */
function fnLoadTravelsDropdown(data) {

    var sortedList = $.parseJSON(data).sort(SortByName);

    //$('#' + divTravelsFilterControl).html('<img alt="img" src="' + baseURL + 'images/closeseatlayout.png" width="16" class="floatRight pointer" onclick="$(\'#' + divTravelsFilterControl + '\').slideUp(); "/><br/>');
    //loop travels and add to dropdown
    if (b == true) {
        $('#' + divTravelsFilterControl).html('');
        $(sortedList).each(function (index) {
            $('#' + divTravelsFilterControl).append('<input type="checkbox" name="cblTravels" value="' + this.name + '" title="' + this.name + '" />&nbsp;&nbsp;' + this.name + ' </br>');
        });
    }
    else {
        $(sortedList).each(function (index) {
            $('#' + divTravelsFilterControl).append('<input type="checkbox" name="cblTravels" value="' + this.name + '" title="' + this.name + '" />&nbsp;&nbsp;' + this.name + ' </br>');
        });

    }

    $('input[name=cblTravels]').change(function () {
        //searchFilterBarcontrol

        fnFilterTrips(this, null);
        $(this).attr('checked', ($(this).attr('checked')));
        //return false;


    });
    //$('#cbAC').change(function () { fnFilterTrips(this, null); });
}
/* ********************************* */
/* function to load bustype dropdown */
/* ********************************  */
function fnLoadBustypeDropdown() {

    $('#' + divBustypeControl).html('');
    $('#' + divBustypeControl).append('<input type="checkbox" name="cblBustype" id="cbAC" value="AC" title="AC" />&nbsp; AC<br />' +
                                        '<input type="checkbox" name="cblBustype" id="cbNONAC" value="Non AC" title="Non AC" />&nbsp;Non AC<br />' +
                                        '<input type="checkbox" name="cblBustype" id="cbSleeper" value="Sleeper" title="Sleeper" />&nbsp;Sleeper<br />' +
                                        '<input type="checkbox" name="cblBustype" id="cbSemiSleeper" value="SemiSleeper" title="SemiSleeper" />&nbsp;SemiSleeper');

    $('input[name=cblBustype]').change(function () {
        fnFilterTrips(this, null);
        $(this).attr('checked', ($(this).attr('checked')));
        //return false;
    });
}
/* ********************** */
/* function to book seats */
/* ************************/
function BookSeats(tripID, sourceId, destinationId) {


    var inputData = '{ "tripDetails":"' + $('#' + searchDetailsRouteControl).html() +
                                    '", "doj":"' + $('#' + txtDOJControl).val() +
                                    '", "seats":"' + $('#' + selectedSeatsListControl).html() +
                                    '", "fare":"' + $('#' + selectedSeatsFareControl).html() +
                                    '", "boardingDetails":"' + $('#' + hdnSelectedBoardingPointControl).val() +
                                    '", "tripID":"' + $('#hdnSingleTripID').val() +
                                    '", "destinationID":"' + destinationId +
                                    '", "sourceID":"' + sourceId +
                                    '", "busType":"' + $('#hdnSelectedBusType').val() +
                                    '", "busOperator":"' + $('#hdnSelectedBusOperator').val() +
                                    '", "providerName":"' + $('#hdnSelectedProvider').val() + '"}';

    //alert(inputData);
    //$('#' + hdnSelectedDestinationControl).val(),$('#' + hdnSelectedSourceControl).val()
    //validate if atleast one seat is selected and boarding point is selected

    if ($('#' + hdnTripTypeControl).val() == 'return' && ($('#' + selectedSeatsListControl + 'Ret').html() == null || $('#' + selectedSeatsListControl + 'Ret').html() == "")) {
        alert("Please select atleast one seat in return journey.");
        return false;
    }
    if ($('#' + hdnTripTypeControl) == 'return' && $('#' + hdnSelectedBoardingPointControl + 'Ret').val() == "") {
        alert("Please select boarding point in return journey.");
        return false;
    }
    if ($('#' + selectedSeatsListControl).html() == null || $('#' + selectedSeatsListControl).html() == "") {
        if ($('#' + hdnTripTypeControl) == 'return')
            alert("Please select atleast one seat in onward journey.");
        else
            alert("Please select atleast one seat.");
        return false;
    }
    if ($('#' + hdnSelectedBoardingPointControl).val() == "") {
        if ($('#' + hdnTripTypeControl) == 'return')
            alert("Please select boarding point in onward journey.");
        else
            alert("Please select boarding point.");

        return false;
    }
    if ($('#' + selectedSeatsListControl).html() == "" || $('#' + hdnSelectedBoardingPointControl).val() == "") {
        return false;
    }
    else {

        $.ajax({
            type: "POST",
            url: baseURL + "BusService.asmx/SetValues",
            data: inputData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                window.location.href = $('#hdnRedirectPage').val();
            },
            error: function (xhr, status, error) {
                //alert('Call to service failed.');
                alert(xhr.responseText + " \n " + status + " \n " + error);
            }
        });
    }
}


/* ********************** */
/* function to show panel */
/* ********************** */
function fnShowPanel(evt, divID, seatAttribs) {

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
            if (divID == 'details_info' || divID == 'details_infoRet') {
                divObj.style.left = (x - 30) + "px";
                divObj.style.top = (y + 20) + "px";
            }
            divObj.style.display = "block";
        }
    }
}

/****************************/
/* functions to close panel */
/****************************/
function fnClosePanel(getID) {

    if (document.getElementById(getID) != null)
        document.getElementById(getID).style.display = "none";
}

/****************************/
/* functions to sort fields */
/****************************/
//function to sort Fares asc
function SortByFares(x, y) {
    if (x.fares.search(',') != -1) {
        var xfares = x.fares.split(',');
        return xfares[0] - y.fares;
    }
    else
        if (y.fares.search(',') != -1) {
            var yfares = y.fares.split(',');
            return x.fares - yfares[0];
        }
        else {
            return x.fares - y.fares;
        }
}
//function to sort Fares desc
function SortByFaresDesc(x, y) {
    return SortByFares(x, y) * -1;
}
//function to sort availableSeats asc
function SortByAvailableSeats(x, y) {
    return x.availableSeats - y.availableSeats;
}
//function to sort availableSeats desc
function SortByAvailableSeatsDesc(x, y) {
    return SortByAvailableSeats(x, y) * -1;
}
//function to sort duration asc
function SortByDuration(x, y) {

    var xduration = x.duration.split('hrs');
    var yduration = y.duration.split('hrs');
    var xtimes = xduration[0].split(':');
    xtime = (xtimes[0] * 60) + parseInt(xtimes[1]);

    var ytimes = yduration[0].split(':');
    ytime = (ytimes[0] * 60) + parseInt(ytimes[1]);

    return xtime - ytime;
}

//sort by duration desc
function SortByDurationDesc(x, y) {
    return SortByDuration(x, y) * -1;
}
//function to sort arrivalTime asc
function SortByArrivalTime(x, y) {
    if (x.arrivalTime.search('AM') != -1 && y.arrivalTime.search('AM') != -1) {
        var xarrivalTime = x.arrivalTime.split('AM');
        var yarrivalTime = y.arrivalTime.split('AM');
        var xtimes = xarrivalTime[0].split(':');
        xtime = (xtimes[0] * 60) + parseInt(xtimes[1]);

        var ytimes = yarrivalTime[0].split(':');
        ytime = (ytimes[0] * 60) + parseInt(ytimes[1]);

        return xtime - ytime;
    }
    else
        if (x.arrivalTime.search('PM') != -1 && y.arrivalTime.search('PM') != -1) {
            var xarrivalTime = x.arrivalTime.split('AM');
            var yarrivalTime = y.arrivalTime.split('AM');
            var xtimes = xarrivalTime[0].split(':');
            xtime = (xtimes[0] * 60) + parseInt(xtimes[1]);

            var ytimes = yarrivalTime[0].split(':');
            ytime = (ytimes[0] * 60) + parseInt(ytimes[1]);

            return xtime - ytime;
        }
        else {
            return x.arrivalTime - y.arrivalTime;
        }
}
//function to sort arrivalTime desc
function SortByArrivalTimeDesc(x, y) {
    return SortByArrivalTime(x, y) * -1;
}
//sort by boarding time asc
function SortByBoardingTime(x, y) {

    if (x.time.search('AM') != -1 && y.time.search('AM') != -1) {
        var xtime = x.time.split('AM');
        var ytime = y.time.split('AM');
        var xtimes = xtime[0].split(':');
        xtime = (xtimes[0] * 60) + parseInt(xtimes[1]);

        var ytimes = ytime[0].split(':');
        ytime = (ytimes[0] * 60) + parseInt(ytimes[1]);

        return xtime - ytime;

    }
    else
        if (x.time.search('PM') != -1 && y.time.search('PM') != -1) {
            var xtime = x.time.split('PM');
            var ytime = y.time.split('PM');
            var xtimes = xtime[0].split(':');
            xtime = (xtimes[0] * 60) + parseInt(xtimes[1]);

            var ytimes = ytime[0].split(':');
            ytime = (ytimes[0] * 60) + parseInt(ytimes[1]);

            return xtime - ytime;
        }
        else {
            return x.time - y.time;
        }
}
//function to sort departureTime asc
function SortByDepartureTime(x, y) {

    if (x.departureTime.search('AM') != -1 && y.departureTime.search('AM') != -1) {
        var xdepartureTime = x.departureTime.split('AM');
        var ydepartureTime = y.departureTime.split('AM');
        var xtimes = xdepartureTime[0].split(':');
        xtime = (xtimes[0] * 60) + parseInt(xtimes[1]);

        var ytimes = ydepartureTime[0].split(':');
        ytime = (ytimes[0] * 60) + parseInt(ytimes[1]);

        return xtime - ytime;

    }
    else
        if (x.departureTime.search('PM') != -1 && y.departureTime.search('PM') != -1) {
            var xdepartureTime = x.departureTime.split('PM');
            var ydepartureTime = y.departureTime.split('PM');
            var xtimes = xdepartureTime[0].split(':');
            xtime = (xtimes[0] * 60) + parseInt(xtimes[1]);

            var ytimes = ydepartureTime[0].split(':');
            ytime = (ytimes[0] * 60) + parseInt(ytimes[1]);

            return xtime - ytime;
        }
        else {
            return x.departureTime - y.departureTime;
        }
}
//function to sort departureTime desc
function SortByDepartureTimeDesc(x, y) {
    return SortByDepartureTime(x, y) * -1;
}
//function to sort Travels asc
function SortByTravels(x, y) {
    return ((x.travels == y.travels) ? 0 : ((x.travels > y.travels) ? 1 : -1));
}
//function to sort Travels desc
function SortByTravelsDesc(x, y) {
    return SortByTravels(x, y) * -1;
}

//function to sort busType asc
function SortByBusType(x, y) {
    return ((x.busType == y.busType) ? 0 : ((x.busType > y.busType) ? 1 : -1));
}
//function to sort busType desc
function SortByBusTypeDesc(x, y) {
    return SortByBusType(x, y) * -1;
}
//function to sort Location asc
function SortByLocation(x, y) {
    return ((x.location == y.location) ? 0 : ((x.location > y.location) ? 1 : -1));
}
//function to sort Name desc
function SortByLocationDesc(x, y) {
    return SortByLocation(x, y) * -1;
}

//function to sort ID asc
function SortByID(x, y) {
    return x.id - y.id;
}
//function to sort ID desc
function SortByIDDesc(x, y) {
    return SortByID(x, y) * -1;
}
//function to sort Name asc
function SortByName(x, y) {
    return ((x.name == y.name) ? 0 : ((x.name > y.name) ? 1 : -1));
}
//function to sort Name desc
function SortByNameDesc(x, y) {
    return SortByName(x, y) * -1;
}


/************************************/
/* functions to show/hide modify search panel */
/***********************************/
function fnModifySearch() {
    fnLoadCities(null);
    $('#' + modifySearchDetailsControl).slideToggle();
    $("#" + txtDestinationControl).removeAttr("readonly");
}
/************************************/
/* functions to check if round trip */
/***********************************/
function fnIsReturnTrip() {

    if (!$('#' + rbRoundTripControl).is(':checked'))
        $('#' + txtDORControl).val('');

    if ($('#' + txtDORControl).val() != '') {

        if ($('#' + rbRoundTripControl).is(':checked'))
            $('#' + hdnTripTypeControl).val('return');

        fnGetAvailableTrips('{ "sourceId":"' + $('#' + hdnSelectedSourceControl).val() +
                                    '", "destinationId":"' + $('#' + hdnSelectedDestinationControl).val() +
                                        '", "dateofjourney":"' + $('#' + txtDOJControl).val() + '"}', !$('#' + rbRoundTripControl).is(':checked'), 0);
    }
    else {
        if ($('#' + rbRoundTripControl).is(':checked')) {
            alert('Please select return journey date');
            $('#' + rbRoundTripControl).attr('checked', false);
        }
    }
}
/************************************/
/* functions to show/hide clear filters*/
/***********************************/
function fnClearFilters() {
    $('#' + cbACControl).attr('checked', false);
    $('#' + cbNONACControl).attr('checked', false);
    $('#' + cbSleeperControl).attr('checked', false);
    $('#' + cbSemiSleeperControl).attr('checked', false);
    $('input[name=cblTravels]').attr('checked', false);
    fnFilterTrips(this, null);
}
/***************************************************/
/* function to show search results of previous date */
/***************************************************/
function fnGoPrevDate() {
    var selectedJourneyDate = new Date($('#' + txtDOJControl).val().split('-')[2] + '/' + $('#' + txtDOJControl).val().split('-')[1] + '/' + $('#' + txtDOJControl).val().split('-')[0]);
    var currentDate = new Date(serverDate);
    if (currentDate < selectedJourneyDate)
        fnDateSearch(false, $('#' + hdnTripTypeControl).val());
    else
        return false;
}
/***************************************************/
/* function to show search results of next date */
/***************************************************/
function fnGoNextDate() {
    fnDateSearch(true, $('#' + hdnTripTypeControl).val());
}


/***************************************************/
/* function to show search results of date search */
/***************************************************/
function fnDateSearch(isNextDate, tripType) {

    var journeyDate = $('#' + txtDOJControl).val();

    journeyDate = journeyDate.split('-')[2] + '/' + journeyDate.split('-')[1] + '/' + journeyDate.split('-')[0];

    var nDate = new Date(journeyDate);

    if (nDate != undefined || nDate != null) {
        var NextDate = (isNextDate) ? new Date(nDate.getFullYear(), nDate.getMonth(), nDate.getDate() + 1) : new Date(nDate.getFullYear(), nDate.getMonth(), nDate.getDate() - 1);

        var journeyYear = NextDate.getFullYear(); //journeyDate.split('/')[0];
        //check next date for december month last date
        //        if (nDate.getMonth() == 11 && nDate.getDate() == daysInMonth(nDate.getMonth(), journeyDate.split('-')[0]))
        //            journeyYear = (isNextDate) ? (journeyDate.split('/')[2] + 1) : (journeyDate.split('/')[2] - 1);

        var Ndate = NextDate.getDate() + '-' + (NextDate.getMonth() + 1) + "-" + journeyYear;

        //set DOJ text field with Ndate
        $('#' + txtDOJControl).val(Ndate);

        //set header display date with Ndate
        $('#' + searchDetailsDOJControl).html(fnGetMonthName($('#' + txtDOJControl).val().split('-')[1]) + ' ' + $('#' + txtDOJControl).val().split('-')[0] + ', ' + $('#' + txtDOJControl).val().split('-')[2]);

        //set hidden fields value based on trip type
        if ($('#' + rbRoundTripControl).is(':checked'))
            $('#' + hdnTripTypeControl).val('return');

        //set DOR text field value based if trip type is return trip
        if ($('#' + rbRoundTripControl).is(':checked') == true) {
            var returnjourneyDate = $('#' + txtDORControl).val();

            returnjourneyDate = returnjourneyDate.split('-')[2] + '/' + returnjourneyDate.split('-')[1] + '/' + returnjourneyDate.split('-')[0];

            var nReturnDate = new Date(returnjourneyDate);

            if (nReturnDate != undefined || nReturnDate != null) {
                var NextReturnDate = (isNextDate) ? new Date(nReturnDate.getFullYear(), nReturnDate.getMonth(), nReturnDate.getDate() + 1) : new Date(nReturnDate.getFullYear(), nReturnDate.getMonth(), nReturnDate.getDate() - 1);

                var returnjourneyYear = returnjourneyDate.split('/')[0];
                //check next date for december month last date
                if (nReturnDate.getMonth() == 11 && nReturnDate.getDate() == daysInMonth(nReturnDate.getMonth(), returnjourneyDate.split('-')[0]))
                    returnjourneyYear = (isNextDate) ? (returnjourneyDate.split('/')[2] + 1) : (returnjourneyDate.split('/')[2] - 1);

                //set DOR text field with Ndate
                $('#' + txtDORControl).val(NextReturnDate.getDate() + '-' + (NextReturnDate.getMonth() + 1) + "-" + returnjourneyYear);
            }
            else
                alert('Please select a valid return journey date.');
        }

        if ($('#' + hdnSelectedSourceControl).val() != '' &&
                $('#' + hdnSelectedDestinationControl).val() != '' &&
                 $('#' + txtDOJControl).val() != '') {
            window.name = 'fromCityId=' + $('#' + hdnSelectedSourceControl).val() +
                                            '&fromCityName=' + $('#' + txtSourceControl).val() +
                                            '&toCityId=' + $('#' + hdnSelectedDestinationControl).val() +
                                            '&toCityName=' + $('#' + txtDestinationControl).val() +
                                            '&doj=' + $('#' + txtDOJControl).val() +
                                            "&dor=" + $('#' + txtDORControl).val() +
                                            '&busType=Any&tripType=' + $('#' + hdnTripTypeControl).val() +
                                            "&bookHotels=" + $('#' + hdnBookHotelControl).val();

            $('#hdnSearchParams').val(window.name);
            fnGetAvailableTrips('{ "sourceId":"' + $('#' + hdnSelectedSourceControl).val() +
                                    '", "destinationId":"' + $('#' + hdnSelectedDestinationControl).val() +
                                        '", "dateofjourney":"' + $('#' + txtDOJControl).val() + '"}', tripType, 0);
        }
        else {
            alert('Please select source, destination and travel date.');
        }
    }
    else
        alert('Please select a valid journey date.');
    return false;
}

function daysInMonth(month, year) {
    return new Date(year, month, 0).getDate();
}

var monthNames = ["January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"];

function fnGetMonthName(month) {
    return monthNames[month - 1];
}

/******************************************/
//function to get journey Duration in hours
/******************************************/
function fnGetJourneyDuration(arg) {

    if (arg != '' && !isNaN(arg)) {
        var minutes = arg % 60;              //remainder
        var hours = parseInt(arg / 60);     //quotient        
        //format hours
        hours = (hours.toString().length == 1) ? ('0' + hours) : hours;
        //format minutes
        minutes = (minutes.toString().length == 1) ? ('0' + minutes) : minutes;
        return hours + ':' + minutes + ' hrs';
    }
    else
        return '-';
}

/******************************************/
//function to build boarding/dropping points
/*****************************************/
function fnBuildBoardingDroppingPoints(arg, argType, isSingleTripData, tripID) {

    var result = '';
    //Build boarding points
    if (arg != null && argType == 'boarding') {

        result += '<dl id="dlBoardingPoints' + tripID + '" class="boardingPoints">';
        result += '<table><tr><td><dt><span class="blackText bold">Location</span></dt></td>';
        result += '<td><dd><span class="blackText bold">Time</span></dd></td></tr></table>';


        var times = $(arg).sort(SortByBoardingTime);
        //var times = $.parseJSON(arg);$(times).sort(SortByDepartureTime)
        //loop boardingTimes and add to ul list
        $(times).each(function (i, item) {
            var locname = item.name.split('^^');
            //            if (locname[0].toString().trim() == "Lakdi") {
            //                var locname = 'LakidiKaPool';
            //                result += '<dt>' + locname + '</dt>';
            //                result += '<dd>' + item.time + '</dd>';
            //            }
            //            else {
            //                result += '<dt>' + locname[0] + '</dt>';
            //                result += '<dd>' + item.time + '</dd>';
            //            }
            if (locname[0].toString().trim() == "Lakdi") {
                var locname = 'LakidiKaPool';
                result += '<table><tr><td><dt>' + locname + '</dt></td>';
                result += '<td><dd>' + item.time + '</dd></td></tr></table>';
            }
            else {
                result += '<table><tr><td><dt>' + locname[0] + '</dt></td>';
                result += '<td><dd>' + item.time + '</dd></td></tr></table>';
            }


        });
        result += '</dl>';

        //add hidden field to store boarding points  - to show in seat layout
        if (isSingleTripData.toString() == 'true')
            result += '<input type="hidden" style="display:none;" id="hdnBoardingPoints' + tripID + '" name="hdnBoardingPoints' + tripID + '" value=' + arg + ' />';
        else
            result += '<input type="hidden" id="hdnBoardingPointsRet' + tripID + '" name="hdnBoardingPointsRet' + tripID + '" value=\'' + arg + '\' />';
    }
    //Build dropping points
    else if (arg != null && argType == 'dropping') {
        //else if (arg != null && argType == 'dropping') {
        result += '<dl id="dlDroppingPoints' + tripID + '" class="boardingPoints">';
        result += '<dt><span class="blackText bold">Location</span></dt>';
        result += '<dd><span class="blackText bold">Time</span></dd>';
        var times = arg;
        //var times = $.parseJSON(arg);
        //loop boardingTimes and add to ul list
        $(times).each(function (i, item) {
            var locname = item.name.split('^^');
            result += '<dt>' + locname[0] + '</dt>';
            result += '<dd>' + item.time + '</dd>';
            //result += '<dd>' + fnGetBoardingDroppingTimes(item.time) + '</dd>';
        });
        result += '</dl>';
    }
    return result;
}

/*************************************************/
//function to build cancellation policy
/*************************************************/
function fnLoadCancellationPolicy(cancellationPolicy, isPartialCancellationAllowed, tripID) {
    //example
    //0:24:100:0;24:72:25:0;72:-1:15:0

    var cancellationPolicyBuilder = '';
    cancellationPolicyBuilder = '<table id="tblCancellationPolicy' + tripID + '" cellspacing="10px" class="cancellationpolicy">' +
                '<tbody> <tr class="redText bold" align="left">' +
                '<th scope="col" style="width: 70%; font-size:12px;" align="left" > Cancellation time </th>' +
                '<th scope="col" style="width: 30%; font-size:12px;" align="left"> Cancellation charges </th> </tr>';

    var attribArrayMain = cancellationPolicy.split(";");

    //split cancellation policy string 
    for (var i = 0; i < attribArrayMain.length; i++) {

        var attribArray = attribArrayMain[i].split(":");

        var cancellationTime = '';
        var cancellationCharges = '';

        //occurs if its last value in cancellation policy string
        if (attribArray[1] == '-1') {
            //build cancellationTime text
            if (parseInt(attribArray[0]) / 24 > 1)
                cancellationTime = (parseInt(attribArray[0]) / 24) + ' days before journey time';
            else
                cancellationTime = attribArray[0] + ' hours before journey time';

            //build cancellationCharges text
            cancellationCharges = attribArray[2] + '.0%';
        }
        else {
            //build cancellationTime text
            cancellationTime = 'Between ' + ((parseInt(attribArray[1]) / 24 > 1) ? ((parseInt(attribArray[1]) / 24) + ' days') : ((parseInt(attribArray[1])) + ' hours'))
                                + ' and ' +
                               ((parseInt(attribArray[0]) / 24 > 1) ? ((parseInt(attribArray[0]) / 24) + ' days') : ((parseInt(attribArray[0])) + ' hours')) +
                                ' before journey time';

            //build cancellationCharges text
            cancellationCharges = attribArray[2] + '.0%';
        }

        cancellationPolicyBuilder += '<tr align="left"> <td>' +
                                    cancellationTime +
                                    '</td> <td align="center">' +
                                    cancellationCharges +
                                    '</td> </tr>';
    }

    //build isPartialCancellationAllowed text
    cancellationPolicyBuilder += '<tr align="left"> <td style="color: Red;">*Partial cancellation ' +
                                    ((isPartialCancellationAllowed) ? "is" : "not") +
                                    ' allowed</td> ' +
                                    '<td align="right"><span style="background-image: url(' + baseURL + 'Images/close_icon.gif); background-repeat: no-repeat; cursor: pointer; background-position: right; padding-right: 20px; margin: 10px; text-decoration: underline;" onclick="$(\'#tblCancellationPolicy' + tripID + '\').hide(); $(\'#overlay\').hide();" >Close</span></td></tr>';
    cancellationPolicyBuilder += '</tbody> </table><div id="overlay" class="web_dialog_overlay"></div>';
    return cancellationPolicyBuilder;
}
//tripID
function fnShowHeaderonScroll() {
    //show modify filter during scroll down
    var div = $("#searchResultsHeaderBar");
    if ($(window).scrollTop() >= 126) {
        div.css('top', '0px');
        div.css('background-color', 'white');
        div.css('z-index', '5');
        //        div.css('padding-top', '10px');
        //        div.css('padding-bottom', '10px');
        div.css('position', 'fixed');
        //  div.css('border-bottom', '0px solid #B1B3B6');
    } else {
        div.css('position', 'relative');
        div.css('top', 'auto');
        div.css('z-index', '0');
        div.css('width', '1000');
        div.css('height', 'auto');
    }
}
function fnShowHeaderonScroll123(tripID) {
    var theDiv = $("#" + tripID);

    //var divTop = theDiv.offset().top;
    var divTop = theDiv.offset().top;
    // alert(divTop);
    //    var winHeight = $(window).height();412,496,580
    //    var divHeight = winHeight - divTop;
    //theDiv.height(divTop);
    if (divTop > 580) {
        $(window).scrollTop(divTop - 50);
    }
    else {

        $(window).scrollTop(divTop - 65);
    }
}

