
function OnSuccess(e) {
    alert(JSON.stringify(e) + JSON.parse(e))
}


$('document').ready(function () {
    $("#imgLoad1").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow1').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
    $("#imgLoad2").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow2').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
    $("#imgLoad3").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow3').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
    $("#imgLoad4").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow4').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
    $("#imgLoad5").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow5').attr('src', e.target.result);
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
            },
            error: function (errormessage) {
                alert("error");
            }
        })
       
        $("#form-product").submit()
        });

});
*/

$(function() {
    $(".remove-product").each(function () {
        $(this).click(() => {
            let id = $(this).data("id")
            let check = confirm(`Are you sure wanna delete this ${id}`)
            if (check) {
                $(`#tr-product__${id}`).remove()
                $.ajax({
                    url: `/Admin/RemoveProduct?Id=${id}`,
                    type: "POST",
                    async: false,
                    success: function (data) {
                        alert(data.text)
                    },
                    error: function (errormessage) {
                        alert("error");
                    }
                })
            }
        });
    });
})




