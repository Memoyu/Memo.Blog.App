import {
  OpenSourceListItem,
  OpenSourceListRequest,
} from "@/types/interfaces/open-source";
import Request from "@/utils/request";

export default {
  openSourceList(request: OpenSourceListRequest) {
    return Request.get<Array<OpenSourceListItem>>("opensource/list", {
      params: request,
    });
  },
};
