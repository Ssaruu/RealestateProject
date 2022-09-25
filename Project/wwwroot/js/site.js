// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var houseIDLabel = document.getElementById("houseIDLabel");
var sizeLabel = document.getElementById("sizeLabel");
var priceLabel = document.getElementById("priceLabel");
var statusLabel = document.getElementById("statusLabel");
var addressLabel = document.getElementById("addressLabel");
var noOfFloorsLabel = document.getElementById("noOfFloorsLabel");





var houseID = document.getElementById("houseId")
var size = document.getElementById("size");
var price = document.getElementById("price");
var status = document.getElementById("status");
var address = document.getElementById("address");
var noOfFloors = document.getElementById("noOfFloors");


function remove(id) {
    var label = document.getElementById(id);
    label.hidden = true;
}