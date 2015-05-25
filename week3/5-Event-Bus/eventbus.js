var bus = (function(){

    var state = [];

    var addCallbackToEventName = function(eventName, callback){
        if(state[eventName] === undefined){
            state[eventName] = [];
        }

        state[eventName].push(callback);

    };

    var removeCallbacksFromEvent = function(eventName){
        if(state.indexOf(eventName) !== -1){
            state[eventName] = [];
        }
    };

    var fireEvent = function(eventName) {
        state[eventName].forEach(function(value){
            value();
        });
    };

    return {
        on: addCallbackToEventName,
        remove: removeCallbacksFromEvent,
        trigger: fireEvent
    }
})();

bus.on("PANIC_EVENT", function() {
    console.log("PANIC_EVENT HAPPENED!");
});

bus.on("PANIC_EVENT", function() {
    console.log("PANIC_EVENT HAPPENED AGAIN!");
});

bus.trigger("PANIC_EVENT");
