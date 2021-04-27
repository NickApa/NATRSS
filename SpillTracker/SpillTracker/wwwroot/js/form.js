
function createNewForm() {

    //var facId = document.getElementById('facilitySelector').options[value.selectedIndex].value;
    var selectedFac = document.getElementById("facilitySelector");
    var facId = selectedFac.value;

    window.location.href = "Forms/Create/" + facId;
}

$(document).ready(function () {
    //auto sets the date picker and time picer on the form to todays date and time when page loaded
    if ($('#SpillReportedDate').length > 0) {
        var date = new Date();

        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear(),
            hour = date.getHours(),
            min = date.getMinutes();

        month = (month < 10 ? "0" : "") + month;
        day = (day < 10 ? "0" : "") + day;
        hour = (hour < 10 ? "0" : "") + hour;
        min = (min < 10 ? "0" : "") + min;

        var today = year + "-" + month + "-" + day,
            displayTime = hour + ":" + min;

        document.getElementById("SpillReportedDate").value = today;
        document.getElementById("SpillReportedDate").max = today;
        document.getElementById("SpillReportedTime").value = displayTime;
    }
});


function displayMap() {
    var checkBox = document.getElementById("spillNotAtFacilityChkbox");
    var map = document.getElementById("interactiveMap");

    if (checkBox.checked == true) {
        map.style.display = "block";
        $("#SpillLocationLabel").text("Spill Coordinates:");
    } else {
        map.style.display = "none";
        $("#SpillLocationLabel").text("Facility Coordinates:");
    }
}

function water() 
{
    var checkBox = document.getElementById("waterCheck");
    var text = document.getElementById("watertext");
    var reachWater = document.getElementById("watercheck");
    

    if (checkBox.checked == true){
        text.style.display = "block";
    } else {
        text.style.display = "none";
    }
}

function puddle() 
{
    var checkBox = document.getElementById("puddleCheck");
    var text = document.getElementById("puddletext");
    

    if (checkBox.checked == true){
        text.style.display = "block";
    } else {
        text.style.display = "none";
    }
}

function submits() 
{
    var checkBox = document.getElementById("submit");
    var div = document.getElementById("submitButton");
    var reachWater = document.getElementById("watercheck");
    

    if (checkBox.checked == true){
        div.style.display = "block";
    } else {
        div.style.display = "none";
    }
}


var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the current tab

function showTab(n) {
  // This function will display the specified tab of the form ...
  var x = document.getElementsByClassName("form-group tab");
  x[n].style.display = "block";
  // ... and fix the Previous/Next buttons:
  if (n == 0) {
    document.getElementById("prevBtn").style.display = "none";
  } else {
    document.getElementById("prevBtn").style.display = "inline";
  }
  if (n == (x.length - 1)) {
    document.getElementById("nextBtn").style.display = "none";
  } else  {
    document.getElementById("nextBtn").style.display = "inline";
  }
  // ... and run a function that displays the correct step indicator:
  fixStepIndicator(n)
}

function nextPrev(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("form-group tab");
    //console.log(x);
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Allow jumping back to this completed page
    var prevTabId = "tab" + currentTab;
    //console.log(prevTabId);
    document.getElementById(prevTabId).setAttribute("onclick", "jumpToTab(" + currentTab + ")");
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form... :
//   if (currentTab >= x.length) {
//     //...the form gets submitted:
//     document.getElementById("regForm").submit();
//     return false;
//   }
  // Otherwise, display the correct tab:

    if (currentTab == 2) {
        var location = $("#SpillLocation").val();
        var date = $("#SpillReportedDate").val()
        var time = $("#SpillReportedTime").val()
        var dateObj = new Date(date + ' ' + time);
        //console.log("location: " + location + ", date: " +  dateObj);
        getWeatherReport(location, dateObj);
    }
    if (currentTab == 3) {
        var chemId = $("#ChemicalId").val();
        //console.log("location: " + location + ", date: " + dateObj);
        loadChemicalData(chemId);
    }
    if (currentTab == 6) {
        //calculate
    }
    if (currentTab == (x.length - 1)) {
        //calculate
    }

    showTab(currentTab);
}

function jumpToTab(n) {
    var x = document.getElementsByClassName("form-group tab");
    x[currentTab].style.display = "none";

    var prevTabId = "tab" + currentTab;
    //console.log(prevTabId);
    document.getElementById(prevTabId).setAttribute("onclick", "jumpToTab(" + currentTab + ")");

    currentTab = n;


    if (currentTab == 2) {
        var location = $("#SpillLocation").val();
        var date = $("#SpillReportedDate").val()
        var time = $("#SpillReportedTime").val()
        var dateObj = new Date(date + ' ' + time);
        //console.log("location: " + location + ", date: " +  dateObj);
        getWeatherReport(location, dateObj);
    }
    if (currentTab == 3) {
        var chemId = $("#ChemicalId").val();
        //console.log("location: " + location + ", date: " + dateObj);
        loadChemicalData(chemId);
    }
    if (currentTab == 6) {
        //calculate
    }

    showTab(currentTab);
}

function fixStepIndicator(n) {
  // This function removes the "active" class of all steps...
  var i, x = document.getElementsByClassName("step");
  for (i = 0; i < x.length; i++) {
    x[i].className = x[i].className.replace(" active", " finish");
  }
  //... and adds the "active" class to the current step:
  x[n].className += " active";
}

function loadChemicalData(id) {
    //console.log("chem id: " + id); 

    $.ajax({
        type: "POST",
        dataType: "json",
        data: { id: id },
        url: "/Forms/GetChemicalData",
        success: successOnAjaxChemData,
        error: errorOnAjaxChemData
    });
}

function errorOnAjaxChemData() {
    console.log("ERROR retrieving chem data");
    alert("error retrieving chem data");
}

var selectedChemical;

function successOnAjaxChemData(data) {
    console.log(data);
    //alert("success getting chem data");

    $("#selectedChem").val(data.chemical.name);
    $("#ChemicalConcentration").val(data.concentration);
    $("#ChemicalTemperature").val(data.chemicalTemperature);

    selectedChemical = data;
    //console.log(selectedChem);

    //set chem state
    var chemStateId = data.chemicalState.id;
    var chemStateSelector = document.getElementById('ChemicalStateId');
    var opts = chemStateSelector.options;
    for (var opt, j = 0; opt = opts[j]; j++) {
        if (opt.value == chemStateId) {
            chemStateSelector.selectedIndex = j;
            break;
        }
    }

    //set temp units
    var tempUnits = data.chemicalTemperatureUnits;
    var chemTempUnitsSelector = document.getElementById('ChemicalTemperatureUnits');
    var opts = chemTempUnitsSelector.options;
    for (var opt, j = 0; opt = opts[j]; j++) {
        //console.log("opt text: " + opt.text + ", temp units: " + tempUnits);
        if (opt.text == tempUnits) {
            chemTempUnitsSelector.selectedIndex = j;
            break;
        }
    }
}

function getWeatherReport(coords, date) {

    var dateTime = date.toLocaleString();
    //console.log("dateTime: " + dateTime);

    $.ajax({
        type: "POST",
        dataType: "json",
        data: { coords: coords, dateTime: dateTime },
        url: "/Forms/GetWeatherReport",
        success: successOnAjaxWeather,
        error: errorOnAjaxWeather
    });
}

function errorOnAjaxWeather() {
    console.log("ERRORgetting weather data");
    alert("error getting weather info");
}

function successOnAjaxWeather(data) {
    console.log(data);
    //alert("success on ajax weather");
    //$("#SpillLocation").val(location);

    $("#weatherLoction").val(data.latitude + ", " + data.longitude);
    $("#SkyConditions").val(data.skyConditions);
    $("#WeatherTemperature").val(data.temperature);
    $("#WindSpeed").val(data.windSpeed);
    $("#WeatherHumidity").val(data.humidity);

    //set temp units
    var tempUnits = data.temperatureUnits;
    var weatherTempUnitsSelector = document.getElementById('WeatherTemperatureUnits');
    var opts = weatherTempUnitsSelector.options;
    for (var opt, j = 0; opt = opts[j]; j++) {
        if (opt.value == tempUnits) {
            weatherTempUnitsSelector.selectedIndex = j;
            break;
        }
    }

    //set wind speed units
    var windSpeedUnits = data.windSpeedUnits;
    var weatherWindSpeedUnitsSelector = document.getElementById('WindSpeedUnits');
    var opts = weatherWindSpeedUnitsSelector.options;
    for (var opt, j = 0; opt = opts[j]; j++) {
        if (opt.value == windSpeedUnits) {
            weatherWindSpeedUnitsSelector.selectedIndex = j;
            break;
        }
    }

    //set wind direction
    var windDirection = data.windDirection;
    var weatherWindDirectionSelector = document.getElementById('WindDirection');
    var opts = weatherWindDirectionSelector.options;
    for (var opt, j = 0; opt = opts[j]; j++) {
        if (opt.value == windDirection) {
            weatherWindDirectionSelector.selectedIndex = j;
            break;
        }
    }

    //set humidity units
    var humidityUnits = data.humidityUnits;
    var weatherHumidityUnitsSelector = document.getElementById('WeatherTemperatureUnits');
    var opts = weatherHumidityUnitsSelector.options;
    for (var opt, j = 0; opt = opts[j]; j++) {
        if (opt.value == humidityUnits) {
            weatherHumidityUnitsSelector.selectedIndex = j;
            break;
        }
    }
}

function calculateSpill() {

    var amountSpilled, volumeSpilled, chemicalConcentration, spillTemperatureF, etaToViolation, evaporationRate,
        spillTemperatureC, windSpeedMPH, windspeedMeterPerSec, spillArea, leakDuration, amountEvaporated;


    chemicalConcentration = $("#ChemicalConcentration").val();
    leakDuration = $("#SpillDurationMin").val() + ($("#SpillDurationHrs").val() * 60);
    spillArea = $("#SpillWidth").val() * $("#SpillLength").val(); 
    
    if ($("#SpillVolumeUnits").val() == "lbs.") {
        volumeSpilled = $("#SpillVolume").val();
        amountSpilled = volumeSpilled * (chemicalConcentration);
        amountSpilled = roundTo(amountSpilled, 2);
    }
    else if ($("#SpillVolumeUnits").val() == "gal.") {
        volumeSpilled = $("#SpillVolume").val();
        amountSpilled = volumeSpilled * chemicalConcentration * selectedChemical.chemical.density;
        amountSpilled = roundTo(amountSpilled, 2);
    }
    //else if ($("#SpillVolumeUnits").val() == "cuft") {
    //    volumeSpilled = $("#SpillVolume").val();
    //    amountSpilled = volumeSpilled * (chemicalConcentration);
    //    amountSpilled = Math.round(amountSpilled, 2);
    //}

    if ($("#ChemicalTemperatureUnits").val() == "&#8457") {
        spillTemperatureF = $("#ChemicalTemperature").val();
        spillTemperatureC = (spillTemperatureF - 32) * (5.0 / 9.0);
    }
    else if ($("#ChemicalTemperatureUnits").val() == "&#8451") {
        spillTemperatureC = $("#ChemicalTemperature").val();
    }

    if ($("#WindSpeedUnits").val() == "MPH") {
        windSpeedMPH = $("#WindSpeed").val();
        windspeedMeterPerSec = windSpeedMPH * 1.60934 * 1000 / 60 / 60;
    }
    else if ($("#WindSpeedUnits").val() == "M/S") {
        windspeedMeterPerSec = $("#WindSpeed").val();
    }

    if ($("#ChemicalStateId").val() == 1) { // solid
        evaporationRate = 0;
        amountEvaporated = 0;
    }
    else if ($("#ChemicalStateId").val() == 2) { // liquid
        evaporationRate = (0.106 * (Math.pow(windspeedMeterPerSec, 0.78)) * (Math.pow(selectedChemical.chemical.molecularWeight, 0.667))
            * spillArea * selectedChemical.chemical.vaporPressure) / (82.05 * (spillTemperatureC + 273));
        amountEvaporated = roundTo((evaporationRate * leakDuration), 2);
        evaporationRate = roundTo(evaporationRate, 2);

        console.log("windspeed (ms): " + roundTo(windspeedMeterPerSec, 2) + ", chem mw: " + roundTo(selectedChemical.chemical.molecularWeight, 2) +
            ", spill area: " + roundTo(spillArea, 2) + ", chem vp: " + roundTo(selectedChemical.chemical.vaporPressure, 2) + ", spill temp c: " + + roundTo(spillTemperatureC, 2));
    }
    else if ($("#ChemicalStateId").val() == 3) { // gas
        //console.log("temp c");
        evaporationRate = 0;
        amountEvaporated = 0;
    }

    //console.log("amnt spilled: " + amountSpilled + ", evap rate: " + evaporationRate + ", amnt evap: " + amountEvaporated);

    $("#AmountSpilled").val(amountSpilled);
    $("#AmountSpilledUnits").val("lbs");
    $("#SpillEvaporationRate").val(evaporationRate);
    $("#SpillEvaporationRateUnits").val("lbs/min");
    $("#AmountEvaporated").val(amountEvaporated);
    $("#AmountEvaporatedUnits").val("lbs");

    var resultsDiv = document.getElementById("spilLresults");
    resultsDiv.style.display = "block";
}

function roundTo(n, digits) {
    //https://stackoverflow.com/questions/15762768/javascript-math-round-to-two-decimal-places
    var negative = false;
    if (digits === undefined) {
        digits = 0;
    }
    if (n < 0) {
        negative = true;
        n = n * -1;
    }
    var multiplicator = Math.pow(10, digits);
    n = parseFloat((n * multiplicator).toFixed(11));
    n = (Math.round(n) / multiplicator).toFixed(digits);
    if (negative) {
        n = (n * -1).toFixed(digits);
    }
    return n;
}
