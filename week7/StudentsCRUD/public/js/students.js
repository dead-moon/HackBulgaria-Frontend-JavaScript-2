var Students = (function(){

    var students = {};

    var getAllStudents = function() {
        $.get( "/users", function( data ) {
            students = data;
        });

        displayTable();
    };

    var getStudentById = function(id) {

    };

    var updateStudentById = function(id) {

    };

    var deleteStudentById = function(id) {

    };

    var displayTable = function() {
        var StudentListSelector = "#studentsList";

        $(StudentListSelector).empty();
        students.forEach(function(student){
            var rowElement = $("<tr></tr>");
            var IdElement = $("<td>" + student.id + "</td>");
        });

    };

    return {
        getAllStudents: getAllStudents,
        getStudentById: getStudentById,
        updateStudentById: updateStudentById,
        deleteStudentById: deleteStudentById,
        displayTable: displayTable
    }

})();