var g_ValidateUserURL = 'http://localhost:59070/Base/ValidateUser';
var g_loginPage = 'http://localhost:59070/Base/Logon';
$(document).ready(function () {
    $('#votePoll').hide();
    $('.voteImg').hover(function () {
        $(this).css('box-shadow', '0px 0px 5px 5px black');
    }, function () {
        $(this).css('box-shadow', '0px 0px 0px 0px black');
    });

    $('.voteImg').click(function () {
        $('.voteImg').css('box-shadow', '0px 0px 0px 0px black');
        $(this).css('box-shadow', '0px 0px 5px 5px black');
    });

    $('#goLive').click(function () {
        window.location.href = liveMapUrl;
    });

    $('#userMap').click(function () {
        window.location.href = userMapUrl;
    });

    $('#voteNotify').click(function () {
        $(this).hide();
        $('#votePoll').show();
        $('#votePoll').animate({ left: '0%' }, 1000);

    });
    $('#closeCategory').on('click', function () {
        $('#votePoll').animate({ left: '-150%' }, 1000).hide();
        $('#voteNotify').show();
    });
    $('#loginBtn').click(function () {
        var userId = $('#txtUserid').val();
        var password = $('#txtPassword').val();
        $.post(g_ValidateUserURL, { userId: userId, password: password }, function (data) {
            if (data == false)
                alert('Login failed!');
            else
                window.location.href = data;
        });
    });
    $('#logout').click(function () {
        window.location.href = g_loginPage;
    });

    $('#notification').click(function () {
        var msg = +$(this).text()+0;
        if(msg > 0){
            $('#voteNotify').hide();
            $('#votePoll').show();
            $('#votePoll').animate({ left: '0%' }, 1000);
        }
    });

});