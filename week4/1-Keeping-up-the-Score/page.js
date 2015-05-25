document.addEventListener("DOMContentLoaded", function(event) {

    /* CREATE HTML */
    var create_team = function(team_name){
        var div_team = document.createElement("div");
        div_team.id = "container-team-" + team_name;

        /* create and append description of Team result */
        var label_team = document.createElement("label");
        var label_team_text = document.createTextNode("Team "+ team_name.toUpperCase() +" Score:");
        label_team.appendChild(label_team_text);

        var score_team = document.createElement("span");
        score_team.id = "score-team-" + team_name;
        var score_team_text = document.createTextNode("0");
        score_team.appendChild(score_team_text);

        var div_result_team = document.createElement("div");
        div_result_team.appendChild(label_team);
        div_result_team.appendChild(score_team);

        div_team.appendChild(div_result_team);
        /* end of create and append description of Team result */

        /* create button for Team A */
        var button_team = document.createElement("button");
        button_team.id = "button-team-" + team_name;
        button_team.style.marginTop = "10px";

        var button_team_text = document.createTextNode("Team " + team_name.toUpperCase());
        button_team.appendChild(button_team_text);

        div_team.appendChild(button_team);

        return div_team;
    }

    var container = document.getElementById("container");

    var div_team_a = create_team("a");
    div_team_a.style.textAlign = "center";
    div_team_a.style.float = "left";
    div_team_a.style.width = "50%";

    var div_team_b = create_team("b");
    div_team_b.style.textAlign = "center";
    div_team_b.style.float = "left";
    div_team_b.style.width = "50%";

    container.appendChild(div_team_a);
    container.appendChild(div_team_b);

    /* END OF CREATE HTML */

    var score_a = 0;
    var score_b = 0;
    var increaseScore = function (team_name){
        var score_element = document.getElementById("score-team-" + team_name);
        var score = parseInt(score_element.innerText);
        score++;
    }


});