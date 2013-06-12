<%@ Page Title="Select Bus" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="SelectBus.aspx.cs" Inherits="SelectBus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="height: 50px;">
    </div>
    <%--hidden fields--%>
    <input type="hidden" id="hdnSearchParams" name="hdnSearchParams" />
    <input type="hidden" id="hdnTripType" name="hdnTripType" />
    <input type="hidden" id="hdnResultSetIndex" name="hdnResultSetIndex" value="1" />
    <input type="hidden" id="hdnSingleTripID" name="hdnSingleTripID" />
    <input type="hidden" id="hdnReturnTripID" name="hdnReturnTripID" />
    <input type="hidden" id="hdnAvailableTrips" name="hdnAvailableTrips" />
    <input type="hidden" id="hdnAvailableReturnTrips" name="hdnAvailableReturnTrips" />
    <input type="hidden" id="hdnSpecialPrice" name="hdnSpecialPrice" />
    <input type="hidden" id="hdnSelectedProvider" name="hdnSelectedProvider" />
    <input type="hidden" id="hdnRedirectPage" name="hdnRedirectPage" value="CustInfo.aspx" />
    <input type="hidden" id="hdnSelectedBusOperator" name="hdnSelectedBusOperator" />
    <input type="hidden" id="hdnSelectedBusOperatorRet" name="hdnSelectedBusOperatorRet" />
    <input type="hidden" id="hdnSelectedBusType" name="hdnSelectedBusType" />
    <input type="hidden" id="hdnSelectedBusTypeRet" name="hdnSelectedBusTypeRet" />
    <input type="hidden" id="hdnSelectedBoardingPoint" name="hdnSelectedBoardingPoint" />
    <input type="hidden" id="hdnSelectedBoardingPointRet" name="hdnSelectedBoardingPointRet" />
    <%--used in validation script--%>
    <input type="hidden" id="hdnCurrentSeatSelection" name="hdnCurrentSeatSelection" />
    <%--hidden fields--%>
    <center>
        <div id="content">
            <div id="wrapper">
                <div id="modifySearchBar">
                    <ul>
                        <li><a onclick="fnGoPrevDate();" class="hidden"><<&nbsp;Prev date</a> </li>
                        <li><span id="searchDetailsRoute" class="grayText bold">Trip details</span> </li>
                        <li><span id="searchDetailsDOJ" class="grayTextBold">Wed, Oct 31</span> </li>
                        <li><a onclick="fnGoNextDate();" class="hidden">Next date&nbsp;>></a> </li>
                        <li><a onclick="fnModifySearch()">Modify search </a></li>
                    </ul>
                </div>
                <div id="modifySearchDetailswrapper">
                    <div id="modifySearchDetails" class="hidden">
                        <ul>
                            <li class="label"><span class="required">*</span>From : </li>
                            <li>
                                <%--text box to load source cities--%>
                                <input type="text" id="txtSource" name="txtSource" />
                                <input type="hidden" id="hdnSources" name="hdnSources" />
                                <input type="hidden" id="hdnSelectedSource" name="hdnSelectedSource" />
                            </li>
                            <li class="label"><span class="required">*</span>To : </li>
                            <li>
                                <%--text box to load destination cities--%>
                                <input type="text" id="txtDestination" name="txtDestination" />
                                <input type="hidden" id="hdnDestinations" name="hdnDestinations" />
                                <input type="hidden" id="hdnSelectedDestination" name="hdnSelectedDestination" />
                            </li>
                            <li class="label"><span class="required">*</span>Journey Date : </li>
                            <li>
                                <input type="text" id="txtDOJ" name="txtDOJ" />
                            </li>
                            <li class="label hidden">Return :</li>
                            <li class="hidden">
                                <input type="text" id="txtDOR" name="txtDOR" />
                            </li>                            
                        </ul>
                        <div class="floatRight hidden">
                            <input id="rbRoundTrip" name="rbRoundTrip" type="checkbox" value="false" onclick="fnIsReturnTrip()" />&nbsp;Round
                            Trip
                        </div>
                        <button id="btnSearchBuses" name="btnSearchBuses" onclick="return fnGetTrips()" class="et_srch">
                            Search</button>
                    </div>
                </div>
                <div id="searchResultsHeaderBar">
                    <div id="searchFilterBar" class="hidden">
                        <ul>
                            <li id="searchFilterBusType">
                                <ul id='ulBusFacilities' class="busfacilities">
                                    <li onclick="$('#divTravelsFilter').toggle();"><div id="divTravelsFilter"></div>
                                    </li>
                                    <li onclick="$('#divBustype').toggle();"><div id="divBustype"></div>
                                    </li>                                    
                                    <li>
                                        <label onclick="fnClearFilters()" title='Click here to clear Bustype filters'>
                                            Clear filters</label>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                    <div id="searchSortBar" class="hidden">
                        <table class="tblsearchSortBar">
                            <thead>
                                <tr>
                                    <%--title attribute is used in javascript for sorting purpose--%>
                                    <th class="srColTravels" title="Click here to sort by Travels" title1="asc" onclick="fnFilterTrips(this, 'travels');">
                                        Travels
                                    </th>
                                    <th class="srColBusType" title="Click here to sort by Bus type" title1="asc" onclick="fnFilterTrips(this, 'bustype')">
                                        Bus type
                                    </th>
                                    <th class="srColDeparture" title="Click here to sort by Depatrure time" title1="asc"
                                        onclick="fnFilterTrips(this, 'dep')">
                                        Dep.
                                    </th>
                                    <th class="srColArrival" title="Click here to sort by Arrival time" title1="asc"
                                        onclick="fnFilterTrips(this, 'arr')">
                                        Arr.
                                    </th>                                    
                                    <th class="srColSeats" title="Click here to sort by Seats" title1="asc" onclick="fnFilterTrips(this, 'seats')">
                                        Seats
                                    </th>
                                    <th class="srColFare" title="Click here to sort by Fares" title1="asc" onclick="fnFilterTrips(this, 'fare')">
                                        <span>Fare</span><span class="uarr1"></span>
                                    </th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                    <div id="searchResults">
                    </div>
                </div>
            </div>
            <%--used to show seat details on seat hover in seat layout--%>
            <div id="seat_info" class="hidden">
                <span class="arrow"></span>
                <div class="tool_tip">
                    <p class="">
                        <strong>Seat No:</strong> <span id="seatNo_ttip"></span>
                    </p>
                    <p class="">
                        <strong>Seat Type:</strong> <span id="seatType_ttip"></span>
                    </p>
                    <p class="">
                        <strong>Fare:</strong> Rs. <span id="seatFare_ttip"></span>
                    </p>
                </div>
            </div>
            <%--used to show selected seat details if more than one seat is selected--%>
            <div id="details_info" style="display: none; z-index: 3000;">
                <div class="tool_tip">
                    <span id="seat_details_info" style="display: inline;">
                        <p class="clearFix" style="padding: 5px;">
                            Fare of <strong><span id="seatCount"></span></strong>seat(s) = Rs. <span id="seatFareTotal">
                            </span>
                        </p>
                    </span>
                    <p class="total" style="padding: 5px;">
                        <strong>Total Fare: Rs. <span id="fareTotal"></span></strong>
                    </p>
                </div>
            </div>
             <div id="details_infoRet" style="display: none; z-index: 3000;">
                <div class="tool_tip">
                    <span id="seat_details_infoRet" style="display: inline;">
                        <p class="clearFix" style="padding: 5px;">
                            Fare of <strong><span id="seatCountRet"></span></strong>seat(s) = Rs. <span id="seatFareTotalRet">
                            </span>
                        </p>
                    </span>
                    <p class="total" style="padding: 5px;">
                        <strong>Total Fare: Rs. <span id="fareTotalRet"></span></strong>
                    </p>
                </div>
            </div>
        </div>
    </center>
    <script runat="server">    
        protected String GetServerDate()
        {
            return DateTime.Now.ToString("yyyy/MM/dd");
        }
    </script>
    <script type="text/javascript">
        var baseURL = '../../';
        var serverDate = "<%= GetServerDate()%>";
        //initialize fields and set default properties
        fnSetFields();

        //window.name = "fromCityId=100&fromCityName=Hyderabad&toCityId=103&toCityName=Chennai&doj=31-12-2012";
        if (window.name != null && $.trim(window.name) != '') {
            $('#hdnSearchParams').val(window.name);
            var searchParams = $('#hdnSearchParams').val().split("&");
            //set selected from city id
            $('#hdnSelectedSource').val(searchParams[0].split('=')[1]);
            //set selected from city name
            $('#txtSource').val(searchParams[1].split('=')[1]);
            //set selected to city id
            $('#hdnSelectedDestination').val(searchParams[2].split('=')[1]);
            //set selected to city name
            $('#txtDestination').val(searchParams[3].split('=')[1]);
            //set selected date of journey
            $('#txtDOJ').val(searchParams[4].split('=')[1]);
            //set selected return date
            $('#txtDOR').val(searchParams[5].split('=')[1]);
            //set selected trip type
            $('#hdnTripType').val(searchParams[7].split('=')[1]);

            //set journey date in modify search bar
            fnSetSearchBarContent($('#txtSource').val(), $('#txtDestination').val(), $('#txtDOJ').val(), searchParams[7].split('=')[1]);
            //load list of available trips
            fnGetAvailableTrips('{ "sourceId":"' + searchParams[0].split('=')[1] +
                                '", "destinationId":"' + searchParams[2].split('=')[1] +
                                '", "dateofjourney":"' + searchParams[4].split('=')[1] +
                                '", "resultSetIndex":"' + $('#hdnResultSetIndex').val() + '"}',
                                $('#hdnTripType').val(), $('#hdnResultSetIndex').val());
            //enable modify search option
            fnModifySearch();
        }

        //function to validate user input and redirect user to search results page
        function fnGetTrips() {
            if ($('#hdnSelectedSource').val() != '' && $('#hdnSelectedDestination').val() != '' && $('#txtDOJ').val() != '') {

                //check if round trip is selected and validate if return date is selected
                if ($("input[name=triptype]:checked").val() == 'return' && $('#txtDOR').val() == '') {
                    alert('Please select return journey date');
                    return false;
                }
                //reset result set index value
                $('#hdnResultSetIndex').val('1');
                //set triptype value to 'return' in hdnTripType if date of return is entered
                if ($('#txtDOR').val() != '')
                    $('#hdnTripType').val('return');

                //set values to window.name and load search results on page refresh or when 
                //user comes back from custinfo page
                window.name = "fromCityId=" + $('#hdnSelectedSource').val() +
                                                        "&fromCityName=" + $('#txtSource').val() +
                                                        "&toCityId=" + $('#hdnSelectedDestination').val() +
                                                        "&toCityName=" + $('#txtDestination').val() +
                                                        "&doj=" + $('#txtDOJ').val() +
                                                        "&dor=" + $('#txtDOR').val() +
                                                        "&busType=Any&tripType=" + $('#hdnTripType').val();
                //store the search filter to hdnSearchParams hidden field
                $('#hdnSearchParams').val(window.name);
                var searchParams = $('#hdnSearchParams').val().split("&");
                fnGetAvailableTrips('{ "sourceId":"' + searchParams[0].split('=')[1] +
                                    '", "destinationId":"' + searchParams[2].split('=')[1] +
                                    '", "dateofjourney":"' + searchParams[4].split('=')[1] +
                                    '", "resultSetIndex":"' + $('#hdnResultSetIndex').val() + '"}', 
                                    $('#hdnTripType').val(), $('#hdnResultSetIndex').val());
                //setTimeout(function () {
                //    fnGetAvailableTrips('{ "sourceId":"' + searchParams[0].split('=')[1] +
                //                        '", "destinationId":"' + searchParams[2].split('=')[1] +
                //                        '", "dateofjourney":"' + searchParams[4].split('=')[1] + 
                //                        '", "resultSetIndex":"2"}', $('#hdnTripType').val(), 2);
                //}, 2000);

                fnSetSearchBarContent($('#txtSource').val(), $('#txtDestination').val(), $('#txtDOJ').val(), $('#hdnTripType').val());

                $('#modifySearchDetails').hide();
            }
            else {
                alert('Please select source, destination and travel date.');
            }
            return false;
        }

        //function to set searchbar content
        function fnSetSearchBarContent(source, destination, doj, tripType) {
            //set trip details content in page header section
            $('#searchDetailsRoute').html(source + ' to ' + destination);
            $('#searchDetailsDOJ').html(fnGetMonthName(doj.split('-')[1]) + ' ' + doj.split('-')[0] + ', ' + doj.split('-')[2]);

            //set triptype
            $('#hdnTripType').val(tripType);
            //show/hide return label
            //check roundtrip checkbox value based on trip type
            if (tripType == 'return') {
                $('#tdReturnLabel').show();
                $('#rbRoundTrip').attr('checked', true);
            }
            else {
                $('#tdReturnLabel').hide();
                $('#rbRoundTrip').attr('checked', false);
            }
        }
    </script>
</asp:Content>
