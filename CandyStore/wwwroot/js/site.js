////$(document).ready(function () {
////    console.log("Hello");
////});

$("#uploadPhoto").click(function () {
    var data = new FormData();
    var files = $("#photoUpload").get(0).files;
    if (files.length > 0) {
        data.append("UploadedImage", files[0]);
    }
    $.ajax({
        type: "POST",
        url: "/ApetisaniTypes/UploadPhoto",
        data: data,
        contentType: false,
        processData: false,
        success: function (data) {
            $("#imgURL").val(data.dbPath);
            alert("Success uploading photo!");
        }
        //error: function () {
        //    alert("Error uploading photo!");
        //}
    })
})
$("#uploadPhotoCoffe").click(function () {
    var data = new FormData();
    var files = $("#photoUploadCoffe").get(0).files;
    if (files.length > 0) {
        data.append("UploadedImage", files[0]);
    }
    $.ajax({
        type: "POST",
        url: "/CoffeTypes/UploadPhoto",
        data: data,
        contentType: false,
        processData: false,
        success: function (data) {
            $("#imgURL").val(data.dbPath);
            alert("Success uploading photo!");
        }
        //error: function () {
        //    alert("Error uploading photo!");
        //}
    })
})
$("#uploadPhotoCandy").click(function () {
    var data = new FormData();
    var files = $("#photoUploadCandy").get(0).files;
    if (files.length > 0) {
        data.append("UploadedImage", files[0]);
    }
    $.ajax({
        type: "POST",
        url: "/CandyTypes/UploadPhoto",
        data: data,
        contentType: false,
        processData: false,
        success: function (data) {
            $("#imgURL").val(data.dbPath);
            alert("Success uploading photo!");
        }
        //error: function () {
        //    alert("Error uploading photo!");
        //}
    })
})

function AddApetisanToWishlist(id) {
    $.ajax({
        type: "POST",
        url: "/ApetisaniTypes/AddApetisanToWishlist/" + id,
        success: function (data) {
            //console.log(data);
            if (data.data != "") {
                new Noty({
                    type: 'alert',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    text: 'Successfully Added To Wishlist',
                    theme: 'sunset'
                }).show();
            } else {
                new Noty({
                    type: 'error',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    progressBar: true,
                    text: 'Apetisan Already Exists In The Wishlist',
                    theme: 'sunset'
                }).show();
            }
        },
        error: function () {
            alert("error");
        }
    });
};

function AddCandyToWishlist(id) {
    $.ajax({
        type: "POST",
        url: "/CandyTypes/AddCandyToWishlist/" + id,
        success: function (data) {
            //console.log(data);
            if (data.data != "") {
                new Noty({
                    type: 'alert',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    text: 'Successfully Added To Wishlist',
                    theme: 'sunset'
                }).show();
            } else {
                new Noty({
                    type: 'error',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    progressBar: true,
                    text: 'Candy Already Exists In The Wishlist',
                    theme: 'sunset'
                }).show();
            }
        },
        error: function () {
            alert("error");
        }
    });
};


function AddCoffeToWishlist(id) {
    $.ajax({
        type: "POST",
        url: "/CoffeTypes/AddCoffeToWishlist/" + id,
        success: function (data) {
            //console.log(data);
            if (data.data != "") {
                new Noty({
                    type: 'alert',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    text: 'Successfully Added To Wishlist',
                    theme: 'sunset'
                }).show();
            } else {
                new Noty({
                    type: 'error',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    progressBar: true,
                    text: 'Coffee Already Exists In The Wishlist',
                    theme: 'sunset'
                }).show();
            }
        },
        error: function () {
            alert("error");
        }
    });
};

function AddApetisanToShoppingCart(id) {
    $.ajax({
        type: "POST",
        url: "/ShoppingCart/AddApetisanToShoppingCart/" + id,
        success: function (data) {
            //console.log(data);
            if (data.data != "") {
                new Noty({
                    type: 'alert',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    text: 'Successfully Added To ShoppingCart',
                    theme: 'sunset'
                }).show();
            } else {
                new Noty({
                    type: 'error',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    progressBar: true,
                    text: 'Apetisan Already Exists In The ShoppingCart',
                    theme: 'sunset'
                }).show();
            }
        },
        error: function () {
            alert("error");
        }
    });
};

function AddCandyToShoppingCart(id) {
    $.ajax({
        type: "POST",
        url: "/ShoppingCart/AddCandyToShoppingCart/" + id,
        success: function (data) {
            //console.log(data);
            if (data.data != "") {
                new Noty({
                    type: 'alert',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    text: 'Successfully Added To ShoppingCart',
                    theme: 'sunset'
                }).show();
            } else {
                new Noty({
                    type: 'error',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    progressBar: true,
                    text: 'Candy Already Exists In The ShoppingCart',
                    theme: 'sunset'
                }).show();
            }
        },
        error: function () {
            alert("error");
        }
    });
};


function AddCoffeToShoppingCart(id) {
    $.ajax({
        type: "POST",
        url: "/ShoppingCart/AddCoffeToShoppingCart/" + id,
        success: function (data) {
            //console.log(data);
            if (data.data != "") {
                new Noty({
                    type: 'alert',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    text: 'Successfully Added To ShoppingCart',
                    theme: 'sunset'
                }).show();
            } else {
                new Noty({
                    type: 'error',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    progressBar: true,
                    text: 'Coffee Already Exists In The ShoppingCart',
                    theme: 'sunset'
                }).show();
            }
        },
        error: function () {
            alert("error");
        }
    });
};



