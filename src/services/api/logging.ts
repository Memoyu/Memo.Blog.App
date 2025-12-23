import {
  PaginationResult,
  SystemLogPageItem,
  SystemLogPageRequest,
  VisitLogPageItem,
  VisitLogPageRequest,
} from "@/types/interfaces";
import Request from "@/utils/request";

export default {
  systemLogPage(request: SystemLogPageRequest) {
    return Request.get<PaginationResult<SystemLogPageItem>>(
      "logger/system/page",
      {
        params: request,
      },
    );
  },

  visitLogPage(request: VisitLogPageRequest) {
    return Request.get<PaginationResult<VisitLogPageItem>>(
      "logger/visit/page",
      {
        params: request,
      },
    );
  },
};
