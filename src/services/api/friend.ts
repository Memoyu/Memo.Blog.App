import {
  FriendPageItem,
  FriendPageRequest,
  PaginationResult,
} from "@/types/interfaces";
import Request from "@/utils/request";

export default {
  friendPage(request: FriendPageRequest) {
    return Request.get<PaginationResult<FriendPageItem>>("friend/page", {
      params: request,
    });
  },
};
