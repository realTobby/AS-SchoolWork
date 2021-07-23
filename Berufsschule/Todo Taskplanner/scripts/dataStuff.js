
function updateTable() {
	localStorage.clear();
	if(localStorage.getItem("userTable") != null) {
		var array = JSON.parse(localStorage.getItem("userTable"));
		$("#table td").remove(); 
		$('#table tr:last').after('<tr><td class="tableHeaderStyle">Aufgabe</th><td class="tableHeaderStyle">bis</th><td class="tableHeaderStyle"</th>Kategorie</tr>');;
		for(var i = 0; i < array.length; i++) {

			var tmpAufgabe = array[i][0];
			var tmpbis = array[i][1];
			var tmpKate = array[i][2];

			$('#table tr:last').after('<tr><td class="tableCellStyle">' + tmpAufgabe + '</th><td class="tableCellStyle">' + tmpbis + '</th><td class="tableCellStyle">' + tmpKate + '</th></tr>');;
		}
	}
}
	
function saveData() {

	var array = [];
    $('#table tr').has('td').each(function() {
        var arrayItem = {};
        $('td', $(this)).each(function(index, item) {
            arrayItem[index] = $(item).html();
        });
        array.push(arrayItem);
    });
	localStorage.setItem("userTable", JSON.stringify(array));
}


function buttonSave() {
	var aufgabe = $("#inputField").val();
	var bis = $("#datePicker").val();
	var kategorie = $("#catePicker").val();
	var inputErrorAufgabe = false;
	var inputErrorBis = false;
	if(aufgabe == "") {
		inputErrorAufgabe = true;
	}
	if(bis == "") {
		inputErrorBis = true;
	}

	if(inputErrorAufgabe == true) {
		alert("Leeres Aufgaben feld!");
	}

	if(inputErrorBis == true) {
		alert("Leeres erledigt-bis feld!");
	}

	if(inputErrorAufgabe == false && inputErrorBis == false) {
		$('#table tr:last').after('<tr><td class="tableCellStyle">' + aufgabe + '</th><td class="tableCellStyle">' + bis + '</th><td class="tableCellStyle">' + kategorie + '</th></tr>');;
	}
}

