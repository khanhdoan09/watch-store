
function OnSuccess(e) {
    alert(e.text)
}


$('document').ready(function () {
    $("#imgLoad_1").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow_1').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
    $("#imgLoad_2").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow_2').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
    $("#imgLoad_3").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow_3').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
    $("#imgLoad_4").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow_4').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
    $("#imgLoad_5").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow_5').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
});



let listProduct

/*
$(function () {
    $("#product-submit").on("click", function (e) {
        e.preventDefault()
        let type = $("#type-product").val()
        let search = $("#search-product").val()
     
        $.ajax({
            url: `/Admin/ResponseListProductToAjax?type=${type}&search=${search}`,
            type: "POST",
            async: false,
            success: function (data) {
                listProduct = JSON.parse(data)
                alert(listProduct)
            },
            error: function (errormessage) {
                alert("error");
            }
        })
       
     

});*/


$(function() {
    $(".remove-product").each(function () {
        $(this).click(() => {
            let id = $(this).data("id")
            let check = confirm(`Are you sure wanna delete this ${id}`)
            if (check) {
                $.ajax({
                    url: `/Admin/RemoveProduct?Id=${id}`,
                    type: "POST",
                    async: false,
                    success: function (data) {
                        alert(data.text)
                        $(`#tr-product__${id}`).remove()
                    },
                    error: function (errormessage) {
                        alert("error");
                    }
                })
            }
        });
    });
})


$(function () {
    $(".remove-user").each(function () {
        $(this).click(() => {
            let id = $(this).data("user")
            let check = confirm(`Are you sure wanna delete this ${id}`)
            if (check) {
                $.ajax({
                    url: `/Admin/RemoveCustomer?Id=${id}`,
                    type: "POST",
                    async: false,
                    success: function (data) {
                        alert(data.text)
                        $(`#tr-product__${id}`).remove()
                    },
                    error: function (errormessage) {
                        alert(JSON.stringify(errormessage));
                    }
                })
            }
        });
    });
})




