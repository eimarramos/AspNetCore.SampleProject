import * as fs from 'fs';
import * as path from 'path';
import { spawnSync } from 'child_process';

const baseFolder =
    process.env.APPDATA !== undefined && process.env.APPDATA !== ''
        ? `${process.env.APPDATA}/ASP.NET/https`
        : `${process.env.HOME}/.aspnet/https`;

const certificateArg = process.argv.map(arg => arg.match(/--name=(?<value>.+)/i)).filter(Boolean)[0];
const certificateName = certificateArg ? certificateArg.groups?.value : process.env.npm_package_name;

if (!certificateName) {
    console.error('Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.');
    process.exit(-1);
}

const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

// Check if the certificates exist, and generate them if they don't
if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
    console.log('Certificates not found. Generating certificates using dotnet dev-certs...');
    const result = spawnSync('dotnet', [
        'dev-certs',
        'https',
        '--export-path',
        certFilePath,
        '--format',
        'Pem',
        '--no-password',
    ], { stdio: 'inherit' });

    if (result.status !== 0) {
        console.error('Failed to generate certificates. Ensure you have the .NET SDK installed and try again.');
        process.exit(-1);
    }
}

// Export the paths for use in other files
export const httpsConfig = {
    certFilePath,
    keyFilePath,
};