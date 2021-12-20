export default {
    props: ['pdetail'],
    data: function () {
        return {
            displayModal: false,
            detail: {}
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
    watch: {
        pdetail: {
            handler(newVal, oldVal) {
                this.detail = { ...this.pdetail };
            },
            deep: true
        }
    },
    template: `
    <p-dialog header="業務詳細資料" v-model:visible="displayModal" class="p-modal-sm p-modal-md p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
         <div class="modal-body">
            <div class="container-fluid">
              <div class="p-datatable p-component p-datatable-responsive-scroll">
                    <div class="p-datatable-wrapper">
                      <table class="p-datatable-table">
                            <tbody class="p-datatable-tbody">
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">姓名</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.Name">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">部門</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.Department">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
         </div>
    </p-dialog>`
}