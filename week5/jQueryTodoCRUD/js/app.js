var TodoApp = (function() {
    // private vars
    var tasks = [];
    var index = 0;

    // store the reference with the jQuery selectors here
    var refs = {
        addTask: "input#addTask",
        container: "#container"
    }

    var generateId = function(){
        return ++index;
    }

    var addTask = function(taskName) {
        var task = {
            id: generateId(),
            name: taskName,
            finished: false
        }
        tasks.push(task);
    };

    var getTaskPosById = function(taskid) {
        var pos = null;
        for(var i=0; i < tasks.length; i++){
            if(tasks[i].id == taskid){
                pos = i;
                break;
            }
        }
        return pos;
    }

    var finishTask = function(taskid) {
        var pos = getTaskPosById(taskid);
        if(pos !== null){
            tasks[pos].finished = true;
        }

        displayList();
    };

    var removeTask = function(taskid) {
        var pos = getTaskPosById(taskid);
        if(pos !== null){
            tasks.splice(pos,1);
        }

        displayList();
    };

    var displayList = function(container) {
        $(refs.container).empty(); // clear the contents

        tasks.forEach(function(task){ // loop through the tasks
            var checkboxElementId = task.id;

            var divElement = $("<div></div>");
            var checkboxElementIsDisabled = (task.finished) ? "disabled" : "";//TODO: checked
            var labelElementClass = (task.finished) ? "compete-task" : "";

            var checkboxElement = $("<input type='checkbox' id='" + checkboxElementId + "' " + checkboxElementIsDisabled + ">");
            var checkboxLabel = $("<label for='" + checkboxElementId + "' class='" + labelElementClass + "'>" + task.name + "</label>");
            var btnRemove = $("<button>Remove</button>");

            divElement.append(checkboxElement);
            divElement.append(checkboxLabel);
            divElement.append(btnRemove);

            $(refs.container).append(divElement);
            // append each task

            checkboxElement.click(function(){
                finishTask(checkboxElementId);
            });

            btnRemove.click(function(){
                removeTask(checkboxElementId);
            });

        });
    };

    // public api
    return {
        addTask: addTask,
        finishTask: finishTask,
        displayList: displayList
    };
})();