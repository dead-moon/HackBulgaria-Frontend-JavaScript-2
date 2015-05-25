
$(document).ready(function(){
   //TODO: init refs
    var btnAddTask = "#add_todo";
    var inputTask = "#addTask";

    $(btnAddTask).click(function(){
        var new_task_title = $(inputTask).val();
        if(new_task_title.trim() !== ""){

            TodoApp.addTask(new_task_title);
            TodoApp.displayList();

            $(inputTask).val("");
        }
    });

    TodoApp.displayList();

});