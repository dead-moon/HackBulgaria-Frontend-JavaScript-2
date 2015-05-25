
var queue = (function(){

    var queue_items = [];

    var pushItem = function(item){
        return queue_items.push(item);
    };

    var popItem = function() {
        queue_items.shift()
        return queue_items;
    };

    var isQueueEmpty = function() {
        return (queue_items.length === 0);
    }

    return {
        push : pushItem,
        pop: popItem,
        isEmpty : isQueueEmpty
    };
})();

//test
queue.isEmpty();
queue.push(5);
queue.push(10);
queue.push(11);
queue.pop();
queue.isEmpty();