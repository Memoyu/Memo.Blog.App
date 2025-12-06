import { DashboardStatistics } from "@/types/interfaces";
import Request from "@/utils/request";

export default {
  statistics() {
    return Request.get<DashboardStatistics>("anlyanis/dashboard");
  },
};
