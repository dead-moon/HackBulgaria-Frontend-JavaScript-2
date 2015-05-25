data =
    [
        {
            "id": 2,
            "name": "vasya",
            "email": "email2@fsf.com"
        },
        {
            "id": 3,
            "name": "gosho",
            "email": "gosho@email.com"
        }
    ];
var keywords = "gosh";

var arr_keywords = keywords.match(/([^\s]+)/g);

var matches = [];

data.forEach(function(value) {
    var is_match = false;
    var rg= new RegExp(arr_keywords.join("|"), "g");

    for(var prop in value){
        if(rg.test(value[prop])){
            is_match = true;
            break;
        }
    }
    console.log(value);
});