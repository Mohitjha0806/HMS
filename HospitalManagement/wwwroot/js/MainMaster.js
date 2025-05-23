
    AOS.init();



    function SidebarToggle(id) {
        var parentLi = document.getElementById(id);
        if (!parentLi.classList.contains('show')) {
            parentLi.classList.add('show');
        }
    }

    $('.select2').select2()
    !function ($) {
        "use strict";
        var SweetAlert = function () { };
        SweetAlert.prototype.init = function () {

            $('.Alert-Success').click(function () {
                Swal.fire({
                    type: 'success',
                    title: 'Good job!',
                    text: 'Operation Completed Success!',
                    timer: 2000
                })
            });
            $('.Alert-Confirmation').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to save this record ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Record Saved Successfully!',
                            timer: 2000
                       
                        }
                        )
                    }
                })
            });

            $('.Alert-Download').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to download this record ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Record Download Successfully!',
                            timer: 2000
                        
                        }
                        )
                    }
                })
            });

            $('.Alert-Reject').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Reject ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Request Rejected Successfully!',
                            timer: 2000
                        
                        }
                        )
                    }
                })
            });

            $('.Alert-Generate').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Generate Order ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Order Generated!',
                            timer: 2000
                        
                        }
                        )
                    }
                })
            });

            $('.Alert-Verified').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Verify ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Records Verified Successfully!',
                            timer: 2000
                        
                        }
                        )
                    }
                })
            });

            $('.Alert-Sendrequest').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to send Request To Head Office ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Request Send Successfully!',
                            timer: 2000
                        
                        }
                        )
                    }
                })
            });
            $('.Alert-Sankul').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Verify Create Sankul ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Sankul Created Successfully!',
                            timer: 2000
                        
                        }
                        )
                    }
                })
            });
            $('.Alert-Close').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to close school ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'School Closed Successfully!',
                            timer: 2000
                        
                        }
                        )
                    }
                })
            });
        },
            $.SweetAlert = new SweetAlert, $.SweetAlert.Constructor = SweetAlert
    }(window.jQuery),
        function ($) {
            "use strict";
            $.SweetAlert.init()
        }(window.jQuery);


    !function ($) {
        "use strict";
        var SweetAlert = function () { };
        SweetAlert.prototype.init = function () {
            $('.Alert-Delete').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Delete Details?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Details Deleted Successfully!',
                            timer: 2000
                        
                        }
                        )
                    }
                })
            });
            $('.Alert-Edit').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Edit Details?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
               
                }).then((result) => {
                
                })
            });
        },
            $.SweetAlert = new SweetAlert, $.SweetAlert.Constructor = SweetAlert
    }(window.jQuery),
        function ($) {
            "use strict";
            $.SweetAlert.init()
        }(window.jQuery);
    AOS.init();

    function SidebarToggle(id) {
        var parentLi = document.getElementById(id);
        if (!parentLi.classList.contains('show')) {
            parentLi.classList.add('show');
        }
    }

    $('.select2').select2();

    (function ($) {
        "use strict";
        var SweetAlert = function () { };
        SweetAlert.prototype.init = function () {

            $('.Alert-Success').click(function () {
                Swal.fire({
                    type: 'success',
                    title: 'Good job!',
                    text: 'Operation Completed Success!',
                    timer: 2000
                });
            });

            $('.Alert-Confirmation').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to save this record ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Record Saved Successfully!',
                            timer: 2000
                        });
                    }
                });
            });

            $('.Alert-Download').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to download this record ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Record Download Successfully!',
                            timer: 2000
                        });
                    }
                });
            });

            $('.Alert-Reject').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Reject ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Request Rejected Successfully!',
                            timer: 2000
                        });
                    }
                });
            });

            $('.Alert-Generate').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Generate Order ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Order Generated!',
                            timer: 2000
                        });
                    }
                });
            });

            $('.Alert-Verified').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Verify ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Records Verified Successfully!',
                            timer: 2000
                        });
                    }
                });
            });

            $('.Alert-Sendrequest').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to send Request To Head Office ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Request Send Successfully!',
                            timer: 2000
                        });
                    }
                });
            });

            $('.Alert-Sankul').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Verify Create Sankul ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Sankul Created Successfully!',
                            timer: 2000
                        });
                    }
                });
            });

            $('.Alert-Close').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to close school ?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'School Closed Successfully!',
                            timer: 2000
                        });
                    }
                });
            });
        };
        $.SweetAlert = new SweetAlert();
        $.SweetAlert.Constructor = SweetAlert;
    })(window.jQuery);

    (function ($) {
        "use strict";
        $.SweetAlert.init();
    })(window.jQuery);

    (function ($) {
        "use strict";
        var SweetAlert = function () { };
        SweetAlert.prototype.init = function () {
            $('.Alert-Delete').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Delete Details?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire({
                            type: 'success',
                            title: 'Success!',
                            text: 'Details Deleted Successfully!',
                            timer: 2000
                        });
                    }
                });
            });

            $('.Alert-Edit').click(function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Do you want to Edit Details?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085D6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes'
                }).then((result) => {
                    // No further action
                });
            });
        };
        $.SweetAlert = new SweetAlert();
        $.SweetAlert.Constructor = SweetAlert;
    })(window.jQuery);

    (function ($) {
        "use strict";
        $.SweetAlert.init();
    })(window.jQuery);
