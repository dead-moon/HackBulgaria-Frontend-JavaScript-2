'use strict';

$(document).ready(function () {

    var pinterestResource = new Resource("https://ismaelc-pinterest.p.mashape.com/vasya_alexieva/boards");

    var displayResult = function(res){
        console.log(res)

        return res;
    }
    pinterestResource.query().then(displayResult);
});