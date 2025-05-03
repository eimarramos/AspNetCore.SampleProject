import { reactRouter } from "@react-router/dev/vite";
import { defineConfig } from "vite";
import tsconfigPaths from "vite-tsconfig-paths";
import { httpsConfig } from './aspnetcore-https';


export default defineConfig({
  plugins: [reactRouter(), tsconfigPaths()],
    server: {
        https: {
            key: httpsConfig.keyFilePath,
            cert: httpsConfig.certFilePath,
        },
    },
});
