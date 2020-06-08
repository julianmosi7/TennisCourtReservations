$(document).ready(_ => {
    console.log("ready");
    let tbl = $('#tablePersons')
    let tblb = $('#tableBodyPersons');   
   

    $.ajax({
        url: 'https://localhost:5001/Persons',
        method: 'GET'
    }).then(x => {
        data.forEach(x => {
            console.log(x);
            let tr = $('<tr>').appendTo(tblb);
            $('<td>').html(x.firstname).appendTo(tr);
            $('<td>').html(x.lastname).appendTo(tr);
            $('<td>').html(x.age).appendTo(tr);
            $('<td>').html(x.nrReservations).appendTo(tr);

        })
    })

    
})