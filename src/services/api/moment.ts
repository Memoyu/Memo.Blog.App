import {
  MomentPageItem,
  MomentPageRequest,
  PaginationResult,
} from "@/types/interfaces";
import Request from "@/utils/request";

export default {
  momentPage(request: MomentPageRequest) {
    return Request.get<PaginationResult<MomentPageItem>>("moment/page", {
      params: request,
    });
  },
};
