"use strict";

var prompt = require('prompt');
var jf = require('jsonfile');

var file = 'data/users.json';

var ConsoleCRUD = function () {

    //users data
    var data = [];

    /**
     * Dictionary with all available commands
     * command_name: command_method
     *
     * Last assigned
     */
    var commands = {};

    /**
     * Display list with users
     */
    var printList = function(){
        console.log("Id | Name | Email");

        data.forEach(function(value){
            console.log(value.id + ", " + value.name + ", " + value.email);
        })

        promptMenuCommand();
    };

    /**
     * Add new user
     *
     * prompt parameters
     * @param item_id
     */
    var promptAddItem = function() {
        console.log("Add element:");
        prompt.get(prop_add, function (err, result) {

            var item = {
                id: getNextId(),
                name: result.name,
                email: result.email
            }
            data.push(item);

            console.log("The item " + result.name + "was added.");
            printMenu();
        });
    };

    /**
     * Get item index in users data array by property 'id'
     * help method
     *
     * @param id
     * @returns {number}
     */
    var getElementPosById = function(id) {
        id = parseInt(id);
        var item_pos = data.map(function(x) {return x.id; }).indexOf(id);

        return item_pos;
    };

    /**
     * Find and display user by property 'id'
     *
     * prompt parameters
     * @param item_id
     */
    var promptGetItemById = function() {

        prompt.get(prop_id, function (err, result) {
            console.log("Element with id: " + result.id_item);

            var item_pos = getElementPosById(result.id_item);
            if(item_pos !== -1) {
                var item = data[item_pos];
                console.log(item.id + " | " + item.name + " | " + item.email);
            }
            else {
                console.log("This item doesn't exist");
            }

            printMenu();
        });
    };

    /**
     * Remove user by property 'id'
     *
     * prompt parameters
     * @param item_id
     */
    var promptRemoveById = function(){
        prompt.get(prop_id, function (err, result) {
            console.log("Delete element with id: " + result.id_item);

            var item_pos = getElementPosById(result.id_item);
            if(item_pos !== -1) {
                data.splice(item_pos, 1);
                console.log("The element is removed.");
            }
            else {
                console.log("This item doesn't exist");
            }

            printMenu();
        });
    };

    /**
     * Update user by property 'id'
     *
     * prompt parameters
     * @param id
     * @param field
     * @param value
     */
    var promptUpdateById = function(){
        prompt.get(prop_update, function (err, result) {

            console.log("Update element with id: " + result.id);

            var item_pos = getElementPosById(result.id);
            if(item_pos !== -1) {

                if(data[item_pos][result.field] !== undefined) {
                   data[item_pos][result.field] = result.value;
                }
                console.log("The element is updated.");
            }
            else {
                console.log("This item doesn't exist");
            }

            printMenu();
        });
    };

    /**
     * Load users data from file
     */
    var loadFromFile = function() {
        data = jf.readFileSync(file);

        printMenu();
    };

    /**
     * Save users data to file
     */
    var saveToFile = function() {
        jf.writeFileSync(file, data)

        printMenu();
    };

    /**
     * Search by one or more keywords separated with spaces
     */
    var searchByKeywords = function() {
        prompt.get(['keywords'], function (err, result) {

            var arr_keywords = result.keywords.match(/([^\s]+)/g);

            data.forEach(function(value){
                var is_match = false;
                for(var prop in value){
                    if(arr_keywords.indexOf(prop)){
                        is_match = true;
                        continue;
                    }
                    console.log(value);
                }
            });
        });
    };
    /**
     * Quit from application
     */
    var quitApp = function() {
        process.exit();
    };

    //Available commands
    commands = {
        list:   printList,
        add:    promptAddItem,
        get:    promptGetItemById,
        remove: promptRemoveById,
        update: promptUpdateById,
        load:   loadFromFile,
        save:   saveToFile,
        search: searchByKeywords,
        quit:   quitApp
    };

    var getNextId = function() {
        var last_id = data.slice(-1)[0].id;
        return  last_id + 1;
    };

    var generateActionPattern = function() {
        var list_actions = [];
        var str_list_actions = "";

        Object.keys(commands).forEach(function(value){
            list_actions.push("(" + value + ")");
        });
        str_list_actions = list_actions.join("|");

        return new RegExp(str_list_actions); //TODO: need to be refactored
    }

    //prompt properties
    var prop_menu = {
        name: 'command',
        validator: generateActionPattern(),
        warning: 'Please select command from the menu!',
        empty: false
    };

    var prop_id = {
        name: 'id_item',
        validator: /^\d+$/,
        empty: false
    };

    var prop_add = {
        properties: {
            name: {
                pattern: /^[a-zA-Z\s-]+$/,
                message: 'Name must be only letters, spaces, or dashes',
                required: true
            },
            email: {
                name: 'email',
                format: 'email',
                message: 'Must be a valid email address',
                required: true
            }
        }
    };

    var prop_update = {
        properties: {
            id : prop_id,
            field: {
                pattern: /^(name)|(email)$/,
                message: 'You can update only name and email properties.',
                required: true
            },
            value: {
                required: true
            }
        }
    };

    var printMenu = function(){
        console.log("Choose command:");
        console.log("---------------");

        for(var command in commands){
            console.log(command);
        };

        console.log("---------------");
        promptMenuCommand();
    };

    var  promptMenuCommand = function(){
        prompt.get(prop_menu, function (err, result) {

            resetConsole();
            (commands[result.command])();

        });
    };

    var resetConsole = function() {
        console.reset = function () {
            return process.stdout.write('\x1Bc');
        };
    };

    var startApp = function() {
        printMenu();
    };

    return {
        start: startApp
    };

};

prompt.start();
ConsoleCRUD().start();

