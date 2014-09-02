/// <reference path="../../Scripts/jquery-2.1.1.js" />

function insertElementBefore(newElement, element) {
    var $newElement = $(newElement);
    var $element = $(element);
    $newElement.insertBefore($element);
}

function insertElementAfter(newElement, element) {
    var $newElement = $(newElement);
    var $element = $(element);
    $newElement.insertAfter($element);
}

$(function () {
    insertElementBefore($('<strong />'), $('.some-element'));
    insertElementAfter($('<em />'), $('.some-element'));
});