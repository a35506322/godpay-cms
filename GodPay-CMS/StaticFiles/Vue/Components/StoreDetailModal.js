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
    <p-dialog header="特店詳細資料" v-model:visible="displayModal" v-bind:style="{width:'50vw'}" v-bind:position="'top'" v-bind:modal="true">
         <div class="modal-body">
            <div class="container-fluid">
              <div class="p-datatable p-component p-datatable-responsive-scroll">
                    <div class="p-datatable-wrapper">
                      <table class="p-datatable-table">
                            <tbody class="p-datatable-tbody">
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">特店名稱</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.StoreName">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">統一編號</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.TaxId">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">負責人</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.Owner">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">公司地址2</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.Address">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">負責人電子信箱</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.Email">
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