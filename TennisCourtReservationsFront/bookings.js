$(document).ready(_ => {
    console.log("ready");
    let tbl = $('#tableBookings')
    let tblb = $('#tableBodyBookings');
    let currentWeek = 22;    
    loadBookings(0);
   

    $('#weekplus1').on('click', _ => loadBookings(+1))
    $('#weekminus1').on('click', _ => loadBookings(-1))


    function loadBookings(date){
        currentWeek += date;
        $('#kalenderwoche').html(currentWeek);
        tbl.empty();
        $.getJSON(`http://localhost:5000/bookings/`).then(data => {
        console.dir(data);
        var l = 10;
        let tr;
        while(day < 7){
            day++;
            tr = $('<tr>').appendTo(tblb);
            //$('<td>').appendTo(tr).html(n);

            while(hour < 20){
                hour++;
                let tr = $('<td>').html(book(day, hour)).appendTo(tr);
            }
        }
       

      
    })
    }   
    
    function book(day, hour){
        let personIds = data.filter(x => x.dayOfWeek == day && x.hour == hour).map(x => x.personId);
        if(personIds.length === 0){
            return '';
        }
        let person = data.filter(x => x.id === personIds[0])[0];
        return `${person.firstname} ${person.lastname}`
    }

    
})