import $ from '../lib/jquery3.7.1';
$(document).ready(function () {
    function trackAppointmentStatus() {
        $.ajax({
            url: '/api/appointment/get-appointment-by-meeting-day-for-ajax',
            type: 'GET',
            success: function (response) {
                response.forEach(function (appointment){
                    if(appointment.data.status === 8) {
                        $.ajax({
                            url: '/api/rabbitmq/publish-appointment-to-queue/' + appointment.data.id,
                            method: 'POST',
                            success: function (response){
                                console.log(response);
                            },
                            error: function (error) {
                                console.log(error);
                            }
                        });
                    }
                });
            },
            error: function(error) {
                console.log(error);
            }
        });
    }
    setInterval(trackAppointmentStatus, 5000);
}