"use strict";

var prompt = require('prompt');
prompt.start();

var GameBullsAndCows = function () {
    var pattern_4digits_unique_number = /^(?:([0-9])(?!.*\1)){4}$/;

    var gen_number;
    var prop_guess_number = {
        name: 'guess_number',
        validator: pattern_4digits_unique_number, //TODO: the first digit to be != 0
        warning: 'The number should consist 4 unique digits',
        empty: false
    };

    var getRandomInt = function(min, max) {
        return Math.floor(Math.random() * (max - min)) + min;
    }

    var genRandomNumberUniqueDigits = function(min, max) {
        var rnd_number;
        do{
            rnd_number = getRandomInt(min, max);
            var has_unique_digits = pattern_4digits_unique_number.test(rnd_number);
        } while(!has_unique_digits);

        return rnd_number;
    }

    var checkBullsCows = function(guess_nmb){
        var bulls = 0;
        var cows = 0;
        var i = 0;
        var digit_of_guess_number = 0;
        var pos_in_gen_number = -1;

        for(i = 0; i < guess_nmb.length; i++){

            digit_of_guess_number = guess_nmb[i];
            pos_in_gen_number = gen_number.indexOf(digit_of_guess_number);

            if(pos_in_gen_number !== -1){
                if(pos_in_gen_number === i){
                    bulls++;
                }
                else{
                    cows++;
                }
            }
        }

        return {
            "bulls" : bulls,
            "cows" : cows
        }
    }

    var printResult = function(guess) {
        console.log(guess.bulls + ' bulls ' + guess.cows + ' cows');
    }

    var  promptNumber = function(){
        prompt.get(prop_guess_number, function (err, result) {

            if(result.guess_number != gen_number){

                var guess = checkBullsCows(result.guess_number);
                printResult(guess);
                promptNumber();
            }
            else{
                console.log("Congrats, you guess the number!");
            }
        });
    }

    var startGame = function() {
        gen_number = "" + genRandomNumberUniqueDigits(1000,9999);
        console.log("Debug: ", gen_number);
        promptNumber();
    }

    return {
        start: startGame
    }

};

GameBullsAndCows().start();

