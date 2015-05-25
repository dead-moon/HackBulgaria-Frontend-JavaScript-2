function MainCtrl($scope) {
    $scope.tasks = [];
    var index = 0;

    var generateId = function() {
    	return ++index;
    }

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

    $scope.addTask = function(value){
        var task = {
        	id: generateId,
        	name: value,
        	finished: false
        }

        $scope.tasks.push(task);
        $scope.task = {};
    }

    $scope.finishTask = function(index){
    	 var pos = getTaskPosById(index);
        if(pos !== null){
            $scope.tasks[pos].finished = true;
        }

    }

    $scope.removeTask = function(index) {
        var pos = getTaskPosById(taskid);
        if(pos !== null){
            $scope.tasks.splice(pos,1);
        }
    }

    $scope.saveTask = function(index, value) {
    	if(index !== undefinded )	
    }

}
