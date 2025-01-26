  function Login(e) {
        e.preventDefault();
        //debugger;
        var Username = $("#user_login").val();
        var Password = $("#user_pass").val();
        if (Username.length == 0 && Password.length == 0 || Username.length == 0 && Password.length < 6) {
            closeModalLogin();
            Swal.fire({
                title: 'Đăng nhập không thành công',
                text: 'Hãy nhập đầy đủ tên đăng nhập và mật khẩu!',
                icon: 'info',
                showCancelButton: false,
                confirmButtonText: 'OK'
            }).then((result) => {
                fcLogin();
                if (result.value) {
                }
            })
        }
        else if (Username.length == 0 && Password.length < 6) {
            closeModalLogin();
            Swal.fire({
                title: 'Đăng nhập không thành công',
                text: 'Mật khẩu ít nhất là 8 kí tự!',
                icon: 'info',
                showCancelButton: false,
                confirmButtonText: 'OK'
            }).then((result) => {
                fcLogin();
                if (result.value) {
                }
            })
        }
        else {
            var obj = {
                "id": 1,
                "accountTypeId": 1000001,
                "accountStatusId": 1000001,
                "roleId": 1000001,
                "active": 1,
                "name": "",
                "email": "",
                "username": $("#user_login").val(),
                "password": $("#user_pass").val(),
                "photo": "",
                "description": "",
                "info": ""
            };

            currentLoggingInUser = obj;
            //debugger;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: '/Login/Login',
                data: { data: JSON.stringify(obj) },
                success: function (responseData) {
                    if (responseData.status == 200 && responseData.message === "SUCCESS"/* && responseData.data[0].isActivated == 0*/) {
                        closeModalLogin();
                        Swal.fire({
                            title: 'Đăng nhập thành công',
                            text: 'Hãy kích hoạt Email: ' + responseData.email + ' để đấu giá tài sản!',
                            footer: "Lưu ý: Website hoạt động tốt nhất với trình duyệt Google Chrome.",
                            icon: 'success',
                            showCancelButton: false,
                            confirmButtonText: 'OK'
                        }).then((result) => {
                            var currentUrl = window.location.href;
                            //if (window.location.pathname == "/Register" || window.location.pathname == "/dang-ky" || window.location.pathname == "/confirmEmail") {
                            //    currentUrl = 'https://lacvietauction.vn/';
                            //}
                            window.location.reload();
                        })
                    }
                    //else if (responseData.status == 200 && responseData.message === "SUCCESS") {
                    //    localStorage.setItem("currentLoggedInUser", JSON.stringify(responseData.data[0]));
                    //    closeModalLogin();
                    //    Swal.fire({
                    //        title: 'Đăng nhập thành công!',
                    //        text: 'Xin chào, ' + responseData.data[0].name + '!',
                    //        footer: "Lưu ý: Website hoạt động tốt nhất với trình duyệt Google Chrome.",
                    //        icon: 'success',
                    //        showCancelButton: false,
                    //        confirmButtonText: 'OK'
                    //    }).then((result) => {
                    //        var currentUrl = window.location.href;
                    //        if (window.location.pathname == "/Register" || window.location.pathname == "/dang-ky" || window.location.pathname == "/confirmEmail") {
                    //            currentUrl = 'https://lacvietauction.vn/';
                    //        }
                    //        if (window.location.pathname.substring(window.location.pathname.indexOf("/"), window.location.pathname.lastIndexOf("/")) == "//AuctionPropertyDetail" || window.location.pathname.substring(window.location.pathname.indexOf("/"), window.location.pathname.lastIndexOf("/")) == "//tai-san-dau-gia" || window.location.pathname.substring(window.location.pathname.indexOf("/"), window.location.pathname.lastIndexOf("/")) == "/AuctionPropertyDetail" ||
                    //            window.location.pathname.substring(window.location.pathname.indexOf("/"), window.location.pathname.lastIndexOf("/")) == "/tai-san-dau-gia"
                    //        ) {
                    //            window.location.reload();
                    //        }
                    //        if (window.location.pathname == "/403.html") {
                    //            window.location.href = currentUrl;
                    //        }
                    //        else {
                    //            window.location.href = currentUrl;
                    //        }
                    //        if (result.value) {
                    //            //alert('login success');
                    //        }
                    //    })
                    //}
                },
                error: function (e) {
                    //console.log(e.message);
                    closeModalLogin();
                    Swal.fire({
                        title: 'Đăng nhập không thành công',
                        text: 'Tài khoản đăng nhập hoặc mật khẩu không chính xác!',
                        icon: 'error',
                        showCancelButton: false,
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        fcLogin();
                        if (result.value) {
                        }
                    });
                }
            });
        }

    }

    function Logout() {
        Swal.fire({
            title: 'Bạn có muốn đăng xuất?',
            text: 'Lạc Việt Auction',
            icon: 'question',
            showCancelButton: true,
            cancelButtonColor: '#443',
            confirmButtonText: 'Xác nhận',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.value) {
                localStorage.clear();
                window.location.href = "/Logout";
            }
        })
    }