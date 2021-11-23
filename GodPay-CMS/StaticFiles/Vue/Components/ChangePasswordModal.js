export default {
    data: function () {
        return {
            displayModal: false
        }
    },
    methods: {
        Show: function () {
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        }
    },
    template: `
    <p-dialog header="變更密碼" v-model:visible="displayModal" v-bind:style="{width:'50vw'}" v-bind:position="'top'" v-bind:modal="true">
         <div class="modal-body">
            <div class="container-fluid">
                <form>
                    <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">舊密碼</label>
                    <input type="password" class="p-inputtext p-component form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                    </div>
                    <div class="mb-3">
                    <label for="exampleInputEmail2" class="form-label">新密碼</label>
                    <input type="password" class="p-inputtext p-component form-control" id="exampleInputEmail2" aria-describedby="emailHelp">
                    </div>
                    <div class="mb-3">
                    <label for="exampleInputEmail3" class="form-label">再次輸入新密碼</label>
                    <input type="password" class="p-inputtext p-component form-control" id="exampleInputEmail3" aria-describedby="emailHelp">
                    </div>
                </form>
            </div>
         </div>
        <div class="p-dialog-footer">
            <p-button label="取消" icon="pi pi-times" v-on:click="Close()" class="p-button-text"></p-button>
            <p-button label="儲存" icon="pi pi-check" autofocus></p-button>
        </div>
    </p-dialog>
    `
}