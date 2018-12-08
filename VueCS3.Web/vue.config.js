'use strict';
const path = require('path');

module.exports = {
	outputDir: path.resolve(__dirname, './wwwroot/dist'),
	baseUrl: '/',
	assetsDir: './assets',
	runtimeCompiler: true,
	chainWebpack: config => {
		const app = config.entry('app');
		app.clear();
		app.add("./Program.ts");

		config.plugin('html').tap(args => {
			return [{
				template: path.resolve(__dirname, './Pages/Shared/_Layout.cshtml')
			}];
		});
	},
	configureWebpack: {
		resolve: {
			alias: {
				"@": path.resolve('Pages'),
				"@assets": path.resolve('wwwroot')
			}
		}
	}
}