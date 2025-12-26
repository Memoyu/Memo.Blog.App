import { Config, ConfigEditBannerRequest } from "@/types/interfaces";
import Request from "@/utils/request";

export default {
  configGet() {
    return Request.get<Config>("config/get");
  },
  configBannerUpdate(banner: ConfigEditBannerRequest) {
    return Request.put<string>("config/update/banner", banner);
  },
};
