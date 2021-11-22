export default {
    data: function () {
        return {
            modal: {}
        }
    },
    mounted: function () {
        this.modal = new bootstrap.Modal(this.$refs.modal);
    },
    methods: {
        Show: function () {
            this.modal.show();
        }
    },
    template: `
    <div class="modal fade" ref="modal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header bg-dark">
            <h4 class="modal-title text-light" id="staticBackdropLabel">變更密碼</h4>
            <button type="button" class="btn text-light p-0" data-bs-dismiss="modal" aria-label="Close">
                <i class="bi bi-x-circle fs-3"></i>
            </button>
          </div>
          <div class="modal-body">
            <div class="container-fluid">
                <form>
                  <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">舊密碼</label>
                    <input type="password" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                  </div>
                 <div class="mb-3">
                    <label for="exampleInputEmail2" class="form-label">新密碼</label>
                    <input type="password" class="form-control" id="exampleInputEmail2" aria-describedby="emailHelp">
                  </div>
                 <div class="mb-3">
                    <label for="exampleInputEmail3" class="form-label">再次輸入新密碼</label>
                    <input type="password" class="form-control" id="exampleInputEmail3" aria-describedby="emailHelp">
                  </div>
                </form>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-success">儲存</button>
          </div>
        </div>
      </div>
    </div>
    `
}