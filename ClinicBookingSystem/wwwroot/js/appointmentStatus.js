import $ from '../lib/jquery3.7.1';
$(document).ready(function () {
    function trackAppointmentStatus(appointmentId) {
        $.ajax({
            url: '/api/appointment/get-appointment-by-id/' + appointmentId,
            Type: 'GET',
            success: function (response) {
                if(response.status === 7) {
                    
                }
            }
        })
    }
}