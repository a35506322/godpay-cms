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
                                            <label class="col-sm-2 col-form-label">全名</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.FullName">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">別名</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.ShortName">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">測試資料</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.StoreData1">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label class="col-sm-2 col-form-label">測試資料2</label>
                                            <div class="col-sm-10">
                                                <input type="text" readonly class="form-control-plaintext outline-none" v-bind:value="detail.StoreData2">
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