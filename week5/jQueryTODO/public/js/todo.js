$(document).ready(function(){
    $("#add_todo").click(function(){
        TodoApp().addTask();
    });

    $("#todo_list input:checkbox").click(function(){
        TodoApp().completeTask();
    });
});

var taskCount = 0;

var tasks = [];
var TodoApp = function(){

    var todo_list = $("#todo_list");
    var task_input = $("#task");

    var getCount = function(){
        return ++taskCount;
    }

    var createTaskTags = function(new_task){
        var divElement = $("<div></div>");
        var checkboxElementId = new_task.id;
        var checkboxElement = $("<input type='checkbox' id='"+checkboxElementId+"'>");
        var checkboxLabel = $("<label for='"+checkboxElementId+"'>" + new_task.name + "</label>");
        divElement.append(checkboxElement);
        divElement.append(checkboxLabel);
        todo_list.append(divElement);

        return checkboxElement;
    };

    var addTask = function (){
        var new_task_title = task_input.val();

        if(new_task_title.trim() !== ""){

            var new_task = {
                id: getCount(),
                name: new_task_title,
                finished: false
            };

            tasks.push(new_task);

            var checkboxElement = createTaskTags(new_task);
            checkboxElement.click(completeTask);

            task_input.val("");
        }

    };

    var completeTask = function(){
        var target_checkbox = $(event.target);
        var target_id = target_checkbox.attr("id");
        var checkbox_label = target_checkbox.next("label");

        target_checkbox.attr("disabled", true);
        checkbox_label.addClass("compete-task");

        tasks[target_id-1].finished = true;

    };

    var listTasks = function(){

    };

    return {
        "addTask": addTask,
        "completeTask": completeTask,
        "listTasks": listTasks
    };

}

