'use strict';

function Resource(url) {
    this.url = url;
}

Resource.prototype.query = function () {
    return Q($.ajax({
        type: "GET",
        "url": this.url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            "X-Mashape-Key":"u8MQ8nhyewmshB7mUjhpt53EVvszp1o2PaOjsnXzUlBeQ73y8h"
        }
    }));
};

Resource.prototype.update = function (id, data) {
    return Q($.ajax({
        type: "PUT",
        "url": this.url + "/" + id,
        "data": data,
        dataType: "json"
    }));
};

Resource.prototype.view = function (id) {
    return Q($.ajax({
        type: "GET",
        "url": this.url + "/" + id,
        dataType: "json"
    }));
};

Resource.prototype.create = function (data) {
    return Q($.ajax({
        type: "POST",
        "url": this.url + "/",
        "data": data,
        dataType: "json"
    }));
};

Resource.prototype.remove = function (id) {
    return Q($.ajax({
        type: "DELETE",
        url: this.url + "/" + id,
        dataType: "json"
    }));
};
